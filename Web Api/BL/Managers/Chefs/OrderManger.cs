using BL.Dtos;
using DAL.Repos.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;
public class OrderManger : IOrderManger
{
    private ICartRepo _repo;

    public bool DeleteOrder(int id)
    {
        bool deleted = _repo.DeleteCart(id); 
        if (deleted == true)
        {
            _repo.SaveChanges();
        }
        return deleted;
    }

    public Task<List<OrderDto>> GetAllOrders(string  id)
    {
        throw new NotImplementedException();
    }
}

