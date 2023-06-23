using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Proposal
{
    public int Id { get; set; }

    public int Price { get; set; }

    public string? Description { get; set; }

    public DateTime Date { get; set; } = DateTime.Now;

    public int PostId { get; set; }

    public string ChefId { get; set; } = string.Empty;

    public virtual Chef Chef { get; set; } = null!;

    public virtual Post Post { get; set; } = null!;
    public virtual PostAcceptedOrder PostAcceptedOrder { get; set; }

}
