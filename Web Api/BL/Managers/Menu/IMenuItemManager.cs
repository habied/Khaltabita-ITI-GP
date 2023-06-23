using BL.Dtos.Menu;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers.Menu
{
    public interface IMenuItemManager
    {
        public List<MenuItemDetailsDto> GetAll();
        public MenuItemDetailsDto? GetMenuItem(int id);
        public Boolean UpdateMenuItem(MenuItemDetailsDto item);
        public Boolean DeleteMenuItem(int id);
        public int AddMenuItem(AddMenuItemDto item);
        public List<MenuItemDetailsDto> GetChefItems(string chefId);
        public Boolean AddLike(int menuItemId, string userId);
        public int[] ChefLikedMenuItems(string userId, string chefId);
        public Boolean DeleteItemLikeByUser(string userId, int menuItemId);
    }
}
