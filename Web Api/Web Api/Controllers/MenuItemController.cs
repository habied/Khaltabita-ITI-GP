using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BL.Managers.Menu;
using BL.Dtos.Menu;
using DAL.Models;

namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        readonly IMenuItemManager _manager;
        public MenuItemController(IMenuItemManager manager)
        {
            _manager = manager;
        }
        [HttpGet]
        public ActionResult<List<MenuItemDetailsDto>> GetAll()
        {
            return _manager.GetAll();
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<MenuItemDetailsDto> Get(int id)
        {
            MenuItemDetailsDto? menuItem = _manager.GetMenuItem(id);
            if (menuItem == null) { return NotFound(); }
            return Ok(menuItem);
        }
        [HttpPost]
        public ActionResult Add(AddMenuItemDto menuItem)
        {
            int? enteries = _manager.AddMenuItem(menuItem);
            if (enteries is null) { return BadRequest(); }
            return Ok();
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            bool success = _manager.DeleteMenuItem(id);
            if (success) { return Ok(); }
            return NotFound();

        }
        [HttpPut]
        public ActionResult Update(MenuItemDetailsDto menuItem)
        {
            bool success = _manager.UpdateMenuItem(menuItem);
            if (success) { return Ok(); }
            return NotFound();
        }
        [HttpGet]
        [Route("ChefItems/{chefid}")]
        public ActionResult<List<MenuItemDetailsDto>> GetChefsItems(string chefid) {
            return _manager.GetChefItems(chefid);
        }
        [HttpGet]
        [Route("AddLike/{userid}/{menuitemid}")]
        public ActionResult AddLike(string userid,int menuitemid)
        {
            bool success=_manager.AddLike(menuitemid, userid);
            if (success) { return Ok(); }
            return NotFound();
        }
        [HttpGet]
        [Route("GetLikes/{userid}/{chefid}")]
        public ActionResult GetChefLikedMenuItems(string userid,string chefid)
        {
            int[] menuItemsIds=_manager.ChefLikedMenuItems(userid, chefid);
            if(menuItemsIds == null) { return BadRequest(); }
            return Ok(menuItemsIds);
        }
        [HttpDelete]
        [Route("DeleteLike/{userid}/{menuitemid}")]
        public ActionResult DeleteMenuItemLike(string userid, int menuitemid)
        {
            bool success = _manager.DeleteItemLikeByUser(userid, menuitemid);
            if (success) { return Ok(); }
            return NotFound();
        }
    }
}
