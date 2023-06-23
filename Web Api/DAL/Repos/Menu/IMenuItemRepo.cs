using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Menu
{
    public interface IMenuItemRepo
    {
        public List<MenuItem> GetAll();
        public MenuItem? GetMenuItem(int id);
        public Boolean UpdateMenuItem(MenuItem item);
        public Boolean DeleteMenuItem(int id);
        public int AddMenuItem(MenuItem item);
        public List<MenuItem> GetChefItems(string chefId);
        public Boolean AddLike(int MenuItemId, string userId);
        public List<MenuItem>? ChefLikedMenuItems(string userId, string chefId);
        public Boolean DeleteItemLikeByUser(string userId, int menuItemId);
    }
}
