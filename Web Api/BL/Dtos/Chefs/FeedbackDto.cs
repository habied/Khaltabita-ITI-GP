namespace BL.Dtos.Chefs;

public class FeedbackDto
{
    public string userId { get; set; } = null!;
    public string? UserName { get; set; }
    public string chefId { get; set; } = string.Empty;

    public string? review { get; set; }

    public double rating { get; set; }

    public string? date { get; set; }
}
