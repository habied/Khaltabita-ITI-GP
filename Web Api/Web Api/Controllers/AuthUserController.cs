using BL.Dtos;
using BL.Dtos.User;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthUserController : ControllerBase
    {
            private readonly IConfiguration _configuration;
            private readonly UserManager<AuthUser> _userManager;

            public AuthUserController(IConfiguration configuration, UserManager<AuthUser> userManager)
            {
                _configuration = configuration;
                _userManager = userManager;
            }

            #region Authentication With ASP Identity
            [HttpPost]
            [Route("login")]
            public async Task<ActionResult<TokenDTO>> Login(LoginDTO credentials)
            {
                var User = await _userManager.FindByEmailAsync(credentials.Email);

                if (User == null)
                {
                    return BadRequest("User not found");
                }
                if (await _userManager.IsLockedOutAsync(User))
                {
                    return BadRequest("Try again");
                }

                bool isAuthenticated = await _userManager.CheckPasswordAsync(User, credentials.Password);
                if (!isAuthenticated)
                {
                    await _userManager.AccessFailedAsync(User);
                    return Unauthorized("Wrong Credentials");
                }


                var userClaims = await _userManager.GetClaimsAsync(User);

                //Generate Key
                var secretKey = _configuration.GetValue<string>("SecretKey");
                
                var secretKeyInBytes = Encoding.ASCII.GetBytes(secretKey);
                var key = new SymmetricSecurityKey(secretKeyInBytes);

                //Determine how to generate hashing result
                SigningCredentials methodUsedInGeneratingToken = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

                var exp = DateTime.Now.AddDays(1);

                //Genete Token 
                var jwt = new JwtSecurityToken(
                    claims: userClaims,
                    notBefore: DateTime.Now,
                    expires: exp,
                    signingCredentials: methodUsedInGeneratingToken);

                 var tokenHandler = new JwtSecurityTokenHandler();
                 string tokenString = tokenHandler.WriteToken(jwt);
                 var claims = await _userManager.GetClaimsAsync(User);
           
                 string title = claims[1].Value; //select the second type ... the role 
                
            
            return new TokenDTO
            {
                Token = tokenString,
                ExpiryDate = exp,
                Id = User.Id,
                Title = title
            };
            }

            [HttpPost]
            [Route("/chef/register")]
            public async Task<ActionResult<string>> ChefRegister(RegisterChef registerChef)
            {
            RegisterChef registerChef1 = registerChef;
            var newChef = new Chef
                {
                    PhoneNumber = registerChef.Mobile,
                    Email = registerChef.Email,
                    PasswordHash = registerChef.Password,
                    Name = registerChef.Name,
                    UserName = registerChef.Email,
                    Address = registerChef.Address,
                    Media = registerChef.Media,
                   
                };

                var creationResult = await _userManager.CreateAsync(newChef, registerChef.Password);

                if (!creationResult.Succeeded)
                {
                    return BadRequest(creationResult.Errors);
                }

                var userClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, newChef.Name),
                new Claim(ClaimTypes.Role, "Chef"),
            };


                await _userManager.AddClaimsAsync(newChef, userClaims);
            var message = new { success = true, message = "This chef was created successfully." };
            return Ok(message);
         
            }


        [HttpPost]
        [Route("/User/register")]
        public async Task<ActionResult<string>> UserRegister(RegisterChef registerDTO)
        {
            var newUser = new User
            {
                Id = registerDTO.Mobile,
                PhoneNumber = registerDTO.Mobile,
                Email = registerDTO.Email,
                PasswordHash = registerDTO.Password,
                Name = registerDTO.Name,
                UserName = registerDTO.Email,
                Address = registerDTO.Address,
            };

            var creationResult = await _userManager.CreateAsync(newUser, registerDTO.Password);

            if (!creationResult.Succeeded)
            {
                return BadRequest(creationResult.Errors);
            }

            var userClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, newUser.Name),
                new Claim(ClaimTypes.Role, "NormalUser"),
            };


            await _userManager.AddClaimsAsync(newUser, userClaims);

            var message = new { success = true, message = "This User was created successfully." };
            return Ok(message);

        }
        #endregion
    }
    }


