using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;

public class OrderDto
{
    public int? Id { get; set; }
    public string? username { get; set; } = null!;
    public string? description { get; set; } = null!;
    public int? Price { get; set; } = 0;
    public string? quantity { get; set; } = null!;
    public string? address { get; set; } = null!;
    public DateTime? date { get; set; } = null!;

    
}
