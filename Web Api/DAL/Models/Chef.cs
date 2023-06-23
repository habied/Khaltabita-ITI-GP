using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models;

public partial class Chef : AuthUser
{
    public string? Media { get; set; }
    [NotMapped]
    public  decimal? Rating { get; }

    public virtual ICollection<Cart> Carts { get; set; }=new List<Cart>();
    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Proposal> Proposals { get; set; } = new List<Proposal>();

    public virtual PostAcceptedOrder PostAcceptedOrder { get; set; }

}
