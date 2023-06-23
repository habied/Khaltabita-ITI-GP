namespace BL.Dtos.Chefs;

public class ChefReadDto
{
    public string ChefId { get; set; } = string.Empty;
    public string ChefName { get; set; } = string.Empty;
    public string ChefAddress { get; set; } = string.Empty;
    public decimal? ChefRating { get; set; }
    public string? ChefPhoto { get; set; }

}
