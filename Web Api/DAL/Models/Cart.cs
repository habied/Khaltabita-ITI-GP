using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models;

public class Cart
{
    public int Id { get; set; }

    public string UserMobile { get; set; } = null!;

    public string Location { get; set; } = null!;

    public DateTime DeliveryDate { get; set; }

    public DateTime OrderDate { get; set; }

    public int TotalPrice { get; set; }

    public int? PostAcceptedOrderId { get; set; }

    public string ChefId { get; set; } = null!;

    public virtual Chef? Chef { get; set; }

    public virtual ICollection<CartMenuItem> CartMenuItems { get; set; } = new List<CartMenuItem>();

    public virtual PostAcceptedOrder? PostAcceptedOrder { get; set; }

    public virtual User UserMobileNavigation { get; set; } = null!;
}
