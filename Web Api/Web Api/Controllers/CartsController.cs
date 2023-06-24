using BL.Dtos.Carts;
using BL.Dtos.Chefs;
using BL.Managers.Carts;
using BL.Managers.Chefs;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartManager _cartManager;
        private readonly IChefManager _chefManager;
        public CartsController(ICartManager cartManager, IChefManager chefManager)
        {
            _cartManager = cartManager;
            _chefManager = chefManager;
        }
        // GET: api/Carts
        [HttpGet]
        public ActionResult<List<CartReadDto>> GetAll()
        {
            return _cartManager.GetAllCarts().ToList(); //200
        }

        // GET: api/Carts/3
        [HttpGet]
        [Route("{id}")]
        public ActionResult<CartReadDto> GetCartById(int id)
        {
            CartReadDto? cartRead = _cartManager.GetCartById(id);
            if (cartRead == null)
            {
                return NotFound();
            }
            return cartRead; //200
        }
        //POST: api/Carts
        [HttpPost]
        public ActionResult AddCart(CartAddDto cartRead)
        {
            int newId = _cartManager.AddCart(cartRead);
            //return CreatedAtAction(
            //    nameof(GetCartById),
            //    new {id = newId},
            //    new { Message = "Cart Added Successfully" }
            //);
            return Content(newId.ToString());
        }
        //POST: api/Carts/Menu
        [HttpPost]
        [Route("Menu")]
        public ActionResult AddCartMenuItem(CartMenuAddDto menuAddDto)
        {
            _cartManager.AddCartMenuItem(menuAddDto);
            return NoContent();
        }

        // DELETE: api/Carts/2
        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteCart(int id)
        {
            var isFound = _cartManager.DeleteCart(id);
            if (!isFound)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpGet]
        [Route("chefcarts/{chefid}")]
        public ActionResult<List<CartReadDto>> GetChefCarts(string chefid)
        {
            ChefReadDto? chef = _chefManager.GetChef(chefid);
            if (chef is null) return NotFound();
            return _cartManager.GetChefCarts(chefid);
        }
    }
}
