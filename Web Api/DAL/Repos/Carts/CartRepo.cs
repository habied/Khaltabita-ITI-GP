using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Repos.Carts
{
    public class CartRepo: ICartRepo
    {
        private readonly FoodyContext _context;
        public CartRepo(FoodyContext context)
        {
            _context = context;
        }

        public List<Cart> GetAllCarts()
        {
            return _context.Set<Cart>().ToList();
        }

        public Cart GetCartById(int id)
        {
            return _context.Set<Cart>().Find(id);
        }

        public void AddCart(Cart cart)
        {
            cart.Id=_context.Set<Cart>().OrderByDescending(x => x.Id).Select(x => x.Id).FirstOrDefault()+1;
            _context.Set<Cart>().Add(cart);
        }
        public void AddCartMenuItem(CartMenuItem cartMenuItem)
        {
            _context.Set<CartMenuItem>().Add(cartMenuItem);
        }
        public Boolean DeleteCart(int id)
        {
            Cart? cart = _context.Set<Cart>().FirstOrDefault(x => x.Id == id);
            if(cart == null) { return false; }
            _context.Set<Cart>().Remove(cart);
            return true;
        }
        public List<Cart> GetChefCarts(string chefId)
        {
            List<Cart> carts = _context.Carts.Where(cart => cart.ChefId == chefId).ToList();
            return carts;
        }
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
