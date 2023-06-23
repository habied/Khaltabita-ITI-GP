using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Carts
{
    public interface ICartRepo
    {

        public List<Cart> GetAllCarts();
        public Cart GetCartById(int id);
        public void AddCart(Cart cart);
        public void AddCartMenuItem(CartMenuItem cartMenuItem);

        public Boolean DeleteCart(int id);
        public List<Cart> GetChefCarts(string chefId);
        int SaveChanges();
    }
}
