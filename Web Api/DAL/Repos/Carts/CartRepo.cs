using DAL.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace DAL.Repos.Carts
{
    public class CartRepo : ICartRepo
    {
        private readonly FoodyContext _context;
        private readonly MyDbContext _ArabicContext;
        public CartRepo(FoodyContext context , MyDbContext arabicContext)
        {
            _context = context;
            _ArabicContext = arabicContext;
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
            cart.Id = _context.Set<Cart>().OrderByDescending(x => x.Id).Select(x => x.Id).FirstOrDefault() + 1;
            _context.Set<Cart>().Add(cart);
        }
        public void AddCartMenuItem(CartMenuItem cartMenuItem)
        {
            _context.Set<CartMenuItem>().Add(cartMenuItem);
        }
        public Boolean DeleteCart(int id)
        {
            Cart? cart = _context.Set<Cart>().FirstOrDefault(x => x.Id == id);
            if (cart == null) { return false; }
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

        public string GetCartItemNames(int cartId)
        {
            var query = @"
    SELECT [dbo].[GetCartItemNames2](@cartId) AS ItemNames FOR JSON PATH;
";

            using var command = _context.Database.GetDbConnection().CreateCommand();
            command.CommandText = query;
            command.Parameters.Add(new SqlParameter("@cartId", cartId));
            _context.Database.OpenConnection();
            var result = command.ExecuteScalar();
            _context.Database.CloseConnection();
            if (result != null)
            {
                var json = JsonDocument.Parse((string)result);
                var itemNames = json.RootElement[0].GetProperty("ItemNames").GetString();
                var items = JsonDocument.Parse(itemNames).RootElement;

                var names = items.EnumerateArray().Select(i => i.GetProperty("Name").GetString());
                result = string.Join(", ", names);
            }
            else
            {
                result = string.Empty;
            }
            return result?.ToString();

        }

        public class MyDbContext : DbContext
        {
            public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
            {
            }

          
        }


    }
}
