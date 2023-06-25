using BL.Dtos;
using BL.Dtos.Carts;
using DAL.Models;
using DAL.Repos.Carts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BL;
public class OrderManger : IOrderManger
{
    private readonly ICartRepo _repo;
    string? des = null;
    string? Qty = null;
    public OrderManger(ICartRepo cartRepo)
    {
        _repo = cartRepo;
    }
    public bool DeleteOrder(int id)
    {
        bool deleted = _repo.DeleteCart(id); 
        if (deleted == true)
        {
            _repo.SaveChanges();
        }
        return deleted;
    }

    public List<OrderDto> GetAllOrders(string  ChefId)
    {
        List<Cart> cart = _repo.GetChefCarts(ChefId);
        
        //int? postId = cart.Select(p => p.PostAcceptedOrderId).FirstOrDefault();
        //if (postId == null)
        //{
           
        //}
        //else
        //{
        //    des = string.Join(", ", cart.Select(c => c.PostAcceptedOrder)
        //                                           .Select(post => post.Description));

        //    Qty = string.Join(", ", cart.Select(c => c.PostAcceptedOrder)
        //                                           .Select(post => post.Quantity));

        //}
        return cart.Select(c => new OrderDto
        {
            Id = c.Id,
            address = c.Location,
            // Price = c.TotalPrice,
            username=c.UserMobile,
            description = _repo.GetCartItemNames(c.Id),
            date =c.DeliveryDate,
        }).ToList();


    }

    
}

/*
    
    public string? username { get; set; } = null!;
    public string? description { get; set; } = null!;
   
    public string? quantity { get; set; } = null!;
    public string? prepTime { get; set; } = null!;
  
    public string? date { get; set; } = null!;





 public int Id { get; set; }

    
    public string Location { get; set; } = null!;

    public DateTime DeliveryDate { get; set; }

    public DateTime OrderDate { get; set; }

    public int TotalPrice { get; set; }

    

    public string ChefId { get; set; } = null!;
    public virtual Chef? Chef { get; set; }


    public virtual ICollection<CartMenuItem> CartMenuItems { get; set; } = new List<CartMenuItem>();


    public virtual PostAcceptedOrder? PostAcceptedOrder { get; set; }
    public int? PostAcceptedOrderId { get; set; }


    public virtual User UserMobileNavigation { get; set; } = null!;
public string UserMobile { get; set; } = null!;


 */