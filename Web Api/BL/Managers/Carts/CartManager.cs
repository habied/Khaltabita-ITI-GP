using BL.Dtos.Carts;
using BL.Dtos.Chefs;
using BL.Dtos.Menu;
using DAL.Models;
using DAL.Repos.Carts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers.Carts
{
    public class CartManager : ICartManager
    {
        private ICartRepo _repo;
        public CartManager(ICartRepo cartRepo)
        {
            _repo = cartRepo;
        }
        public int AddCart(CartAddDto cartDto)
        {
            Cart cart = new Cart
            {
                UserMobile = cartDto.UserMobile,
                Location = cartDto.Location,
                TotalPrice = cartDto.TotalPrice,
                DeliveryDate = DateTime.Now.AddHours(1),
                OrderDate = DateTime.Now,
                ChefId = cartDto.ChefId,
            };
            _repo.AddCart(cart);
            _repo.SaveChanges();
            return cart.Id;
        }
        public void AddCartMenuItem(CartMenuAddDto menuAddDto)
        {
            CartMenuItem item = new CartMenuItem
            {
                CartId = menuAddDto.CartId,
                MenuItemId = menuAddDto.MenuItemId,
                TotalItemPrice = menuAddDto.TotalItemPrice,
                Quantity = menuAddDto.Quantity,
            };

            _repo.AddCartMenuItem(item);
            _repo.SaveChanges();
        }

        public List<CartReadDto> GetAllCarts()
        {
            List<Cart> cart = _repo.GetAllCarts();
            return cart.Select(c => new CartReadDto
            {
                Id = c.Id,
                UserMobile = c.UserMobile,
                Location = c.Location,
                TotalPrice = c.TotalPrice,
                ChefId = c.ChefId,

            }).ToList();
        }

        public CartReadDto? GetCartById(int id)
        {
            Cart? cart = _repo.GetCartById(id);
            if (cart != null)
            {
                return new CartReadDto
                {
                    Id = cart.Id,
                    UserMobile = cart.UserMobile,
                    Location = cart.Location,
                    TotalPrice = cart.TotalPrice,
                    ChefId = cart.ChefId,
                };
            }
            return null;
        }
        public bool DeleteCart(int id)
        {
            bool deleted = _repo.DeleteCart(id);
            if (deleted == true)
            {
                _repo.SaveChanges();
            }
            return deleted;
        }
        public List<CartReadDto> GetChefCarts(string chefId)
        {
            List<Cart> carts = _repo.GetChefCarts(chefId);
            return carts.Select(cart => new CartReadDto
            {
                Id = cart.Id,
                UserMobile = cart.UserMobile,
                Location = cart.Location,
                TotalPrice = cart.TotalPrice,
                ChefId = cart.ChefId,
            }).ToList();
        }

    }
}
