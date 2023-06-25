using BL.Dtos;
using BL.Dtos.Chefs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;

    public interface IOrderManger
    {
    public List<OrderDto> GetAllOrders( string Chefid);
  
    public bool DeleteOrder(int Cartid);
    
}

