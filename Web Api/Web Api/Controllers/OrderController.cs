using BL;
using BL.Dtos.Carts;
using BL.Managers.Carts;
using BL.Managers.Chefs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManger _Order;
        public OrderController(IOrderManger orderManger)
        {
            _Order= orderManger;
        }
        //get all orders 
        [HttpGet]
        [Route("{id}")]
        public ActionResult<List<OrderDto>> GetAll(string id)
        {
            return _Order.GetAllOrders(id); //200
        }

        //delete order means Done 
        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteCart(int id)
        {
            var isFound = _Order.DeleteOrder(id);
            if (!isFound)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
