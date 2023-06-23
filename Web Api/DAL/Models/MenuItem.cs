using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class MenuItem
{
    public string? Name { get; set; }

    public int Id { get; set; }

    public string? Media { get; set; }
    public string? Category { get; set; }

    public string? Description { get; set; }

    public int UnitPriceLE { get; set; }

    public int? PrepTimeMin { get; set; }

    public string? Availability { get; set; }

    public int Likes { get; set; }

    public string? ChefId { get; set; }
    public virtual ICollection<CartMenuItem> CartMenuItems { get; set; } = new List<CartMenuItem>();
    public virtual ICollection<User> UserLikingIt { get; set; }= new List<User>();
}
