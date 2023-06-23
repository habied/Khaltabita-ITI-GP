using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class CartMenuItem
{
    public int MenuItemId { get; set; }

    public int CartId { get; set; }

    public int Quantity { get; set; }

    public int TotalItemPrice { get; set; }

    public virtual Cart Cart { get; set; } = null!;

    public virtual MenuItem MenuItem { get; set; } = null!;
}
