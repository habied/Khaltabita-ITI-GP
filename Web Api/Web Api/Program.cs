
using BL;
using BL.Managers;
using BL.Managers.Carts;
using BL.Managers.Chefs;
using BL.Managers.Menu;
using BL.Managers.Proposal;
using DAL;
using DAL.Models;
using DAL.Repos.Carts;
using DAL.Repos.Chefs;
using DAL.Repos.Menu;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace Web_Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            // Add services to the container.

            builder.Services.AddControllers();

            #region CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.AllowAnyOrigin()
                                      .AllowAnyHeader()
                                      .AllowAnyMethod();
                                  });
            });
            #endregion

            #region context and identity
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connectionString = builder.Configuration.GetConnectionString("Foody-ConnectionString");
            builder.Services.AddDbContext<FoodyContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddIdentity<AuthUser, IdentityRole>()
                    .AddEntityFrameworkStores<FoodyContext>()
                    .AddDefaultTokenProviders();
            #endregion

            #region Layers_Interface_Object
            builder.Services.AddScoped<IMenuItemRepo, MenuItemRepo>();
            builder.Services.AddScoped<IMenuItemManager, MenuItemManager>();
            builder.Services.AddScoped<IChefManager, ChefManager>();
            builder.Services.AddScoped<IChefRepo, ChefRepo>();
            builder.Services.AddScoped<IUserRepo, UserRepo>();
            builder.Services.AddScoped<IPostRepo, PostRepo>();
            builder.Services.AddScoped<IPostManager, PostManager>();
            builder.Services.AddScoped<IProposalRepo, ProposalRepo>();
            builder.Services.AddScoped<IProposalManager, ProposalManager>();
            builder.Services.AddScoped<ICartRepo, CartRepo>();
            builder.Services.AddScoped<ICartManager, CartManager>();
            #endregion


            #region Authentication
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "default";
                options.DefaultChallengeScheme = "default";
            }).
                AddJwtBearer("default", options =>
                {
                    string? secretKey = builder.Configuration.GetValue<string>("SecretKey");
                    
                    var secretKeyInBytes = Encoding.ASCII.GetBytes(secretKey);
                    var key = new SymmetricSecurityKey(secretKeyInBytes);

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        IssuerSigningKey = key
                    };
                });
            #endregion

            #region Authorization
            
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("Chef", policy =>
                    policy
                    .RequireClaim(ClaimTypes.Role, "Chef"));

                options.AddPolicy("NormalUser", policy =>
                    policy
                    .RequireClaim(ClaimTypes.Role, "NormalUser"));

            });

            
            #endregion


            var app = builder.Build();

            #region Middleware
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthentication();
            app.UseAuthorization();
            

            app.MapControllers();



            var staticFilesPath = Path.Combine(Environment.CurrentDirectory, "Images");
            app.UseStaticFiles(new StaticFileOptions
            {

                //FileProvider= new PhysicalFileProvider($"{Environment.CurrentDirectory}\\Images\\")
                FileProvider = new PhysicalFileProvider(staticFilesPath),
                RequestPath = "/Images"

            });


            app.Run();
            #endregion

        }
    }
}