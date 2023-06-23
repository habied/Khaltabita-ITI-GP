using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Menu
{
    public class MenuItemRepo : IMenuItemRepo
    {
        private readonly FoodyContext _context;
        public MenuItemRepo(FoodyContext foodyContext) 
        {
            _context= foodyContext;
        }
        public List<MenuItem> GetAll()
        {
            return _context.MenuItems.ToList();
        }
        public MenuItem? GetMenuItem (int id)
        {
            MenuItem? menuItem= _context.MenuItems.FirstOrDefault(x => x.Id == id);
            if(menuItem == null) { return null; }
            return menuItem;
        }
        public Boolean UpdateMenuItem(MenuItem item)
        {
            MenuItem ?menuItem = _context.MenuItems.FirstOrDefault(x => x.Id == item.Id);
            if(menuItem == null ) { return false; }
            menuItem.Likes = item.Likes;
            menuItem.Name = item.Name;
            menuItem.Description = item.Description;
            menuItem.UnitPriceLE = item.UnitPriceLE;
            menuItem.Availability = item.Availability;
            menuItem.ChefId = item.ChefId;
            menuItem.PrepTimeMin= item.PrepTimeMin;
            _context.SaveChanges();
            return true;
        }
        public Boolean DeleteMenuItem(int id)
        {
            MenuItem? menuItem = _context.MenuItems.FirstOrDefault(x => x.Id == id);
            if(menuItem == null ) { return false; }
            _context.MenuItems.Remove(menuItem);
            _context.SaveChanges();
            return true;
        }
        public int AddMenuItem(MenuItem item)
        {
            _context.MenuItems.Add(item);
            return _context.SaveChanges();
        }
        public List<MenuItem> GetChefItems(string chefId)
        {
            List<MenuItem> items= _context.MenuItems.Where(item=>item.ChefId==chefId).ToList();
            return items;
        }
        public Boolean AddLike (int menuItemId,string userId)
        {
            User ?userLikingItem = _context.Users.FirstOrDefault(u => u.Id == userId);
            MenuItem ?menuItemLiked= _context.MenuItems.FirstOrDefault(mi=>mi.Id==menuItemId);
            if (userLikingItem!=null && menuItemLiked!=null)
            {
                userLikingItem.LikedMenuItem.Add(menuItemLiked);
                
                menuItemLiked.Likes += 1;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public List<MenuItem>? ChefLikedMenuItems(string userId ,string chefId)
        {
            User? userLikingItem = _context.Users.Include(u=>u.LikedMenuItem).FirstOrDefault(u => u.Id == userId);
            if (userLikingItem is null) {return null;}
            List<MenuItem> likedChefMenuItems = userLikingItem.LikedMenuItem.Where(mi=>mi.ChefId==chefId).ToList();
            
            return likedChefMenuItems;
        }
        public Boolean DeleteItemLikeByUser(string userId,int menuItemId)
        {
            User? userLikingItem = _context.Users.Include(u => u.LikedMenuItem).FirstOrDefault(u => u.Id == userId);
            if (userLikingItem is null) { return false; }
            MenuItem? likedItem=userLikingItem.LikedMenuItem.Where(mi=>mi.Id==menuItemId).FirstOrDefault();
            if(likedItem is null) { return false; }
            userLikingItem.LikedMenuItem.Remove(likedItem);
            likedItem.Likes -= 1;
            _context.SaveChanges();
            return true;    

        }
    }
}
