using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Post
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public int? FromPrice { get; set; }

    public int? ToPrice { get; set; }

    public string? QuantityUnit { get; set; }

    public float Quantity { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public DateTime Date { get; set; }= DateTime.Now;
    public string PostState { get; set; } = "Open";
    public string UserId { get; set; } = "";

    public virtual ICollection<Proposal> Proposals { get; set; } = new List<Proposal>();

    public virtual User User { get; set; } = null!;
    public virtual PostAcceptedOrder PostAcceptedOrder { get; set; }


}
