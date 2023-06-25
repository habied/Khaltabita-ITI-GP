using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos;

public class OrderDto
{
    public string username { get; set; } = null!;
    public string userAddress { get; set; } = null!;
    public string description { get; set; } = null!;
    public string Price { get; set; } = null!;
    public string quantity { get; set; } = null!;
    public string prepTime { get; set; } = null!;
    public string address { get; set; } = null!;
    public string date { get; set; } = null!;

    
}
