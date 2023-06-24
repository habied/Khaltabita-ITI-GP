using BL.Dtos.Carts;
using BL.Dtos.Chefs;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers.Carts
{
    public interface ICartManager
    {
        public List<CartReadDto> GetAllCarts();
        CartReadDto? GetCartById(int id);
        public int AddCart(CartAddDto cartDto);
        public void AddCartMenuItem(CartMenuAddDto cartMenuItem);
        public Boolean DeleteCart(int id);
        public List<CartReadDto> GetChefCarts(string chefId);
    }
}
