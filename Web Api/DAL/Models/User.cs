namespace DAL.Models;

public partial class User : AuthUser
{
    public string? Gender { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
    public virtual PostAcceptedOrder PostAcceptedOrder { get; set; }
    public virtual ICollection<MenuItem> LikedMenuItem { get; set; }=new List<MenuItem>();

}
