using BL.Dtos.Menu;
using DAL.Models;
using DAL.Repos.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers.Menu
{
    public class MenuItemManager : IMenuItemManager
    {
        private readonly IMenuItemRepo _repo;
        public MenuItemManager(IMenuItemRepo repo)
        {
            _repo = repo;
        }
        public List<MenuItemDetailsDto> GetAll()
        {
            var menuItems = _repo.GetAll();
            return menuItems.Select(item => new MenuItemDetailsDto
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Availability = item.Availability,
                PrepTime = item.PrepTimeMin,
                ChefId = item.ChefId,
                Likes = item.Likes,
                Media = item.Media,
                UnitPrice = item.UnitPriceLE,
                Category = item.Category,

            }).ToList();
        }
        public MenuItemDetailsDto? GetMenuItem(int id)
        {
            MenuItem? menuItem = _repo.GetMenuItem(id);
            if (menuItem == null) return null;
            return new MenuItemDetailsDto
            {
                Id = menuItem.Id,
                Name = menuItem.Name,
                Description = menuItem.Description,
                Availability = menuItem.Availability,
                PrepTime = menuItem.PrepTimeMin,
                ChefId = menuItem.ChefId,
                Likes = menuItem.Likes,
                Media = menuItem.Media,
                UnitPrice = menuItem.UnitPriceLE,
                Category = menuItem.Category
            };
        }
        public Boolean UpdateMenuItem(MenuItemDetailsDto item)
        {
            MenuItem? menuItem = _repo.GetMenuItem(item.Id);
            if (menuItem == null) return false;
            menuItem.Description = item.Description;
            menuItem.Availability = item.Availability;
            menuItem.UnitPriceLE = item.UnitPrice;
            menuItem.Likes = item.Likes;
            menuItem.Media = item.Media;
            menuItem.ChefId = item.ChefId;
            menuItem.Name = item.Name;
            menuItem.Category = item.Category;
            return _repo.UpdateMenuItem(menuItem);

        }
        public Boolean DeleteMenuItem(int id)
        {
            return _repo.DeleteMenuItem(id);
        }
        public int AddMenuItem(AddMenuItemDto item)
        {
            MenuItem menuItem = new MenuItem
            {
                Description = item.Description,
                Name = item.Name,
                Availability = item.Availability,
                UnitPriceLE = item.UnitPrice,
                ChefId = item.ChefId,
                Media = item.Media,
                PrepTimeMin = item.PrepTime,
                Category = item.Category
            };
            return _repo.AddMenuItem(menuItem);
        }
        public List<MenuItemDetailsDto> GetChefItems(string chefId)
        {
            List<MenuItem> menuItems = _repo.GetChefItems(chefId);
            return menuItems.Select(item => new MenuItemDetailsDto
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Availability = item.Availability,
                PrepTime = item.PrepTimeMin,
                ChefId = item.ChefId,
                Likes = item.Likes,
                Media = item.Media,
                UnitPrice = item.UnitPriceLE,
                Category = item.Category,

            }).ToList();

        }
        public Boolean AddLike(int menuItemId, string userId)
        {
            return _repo.AddLike(menuItemId, userId);
        }
        public int[] ChefLikedMenuItems(string userId, string chefId)
        {
            List<MenuItem>? chefLikedMenuItems = _repo.ChefLikedMenuItems(userId, chefId);
            if (chefLikedMenuItems == null) { return null; }
            return chefLikedMenuItems.Select(menuItem => menuItem.Id).ToArray();
        }
        public Boolean DeleteItemLikeByUser(string userId, int menuItemId)
        {
            return _repo.DeleteItemLikeByUser(userId, menuItemId);
        }
    }
}
