namespace BL;

public class ProposalAddDto
{

    public required int Price { get; set; }

    public required string? Description { get; set; }

    public required int PostId { get; set; }

    public required string ChefId { get; set; }

}
