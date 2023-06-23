using BL.Dtos.Chefs;

namespace BL.Managers.Chefs;

public interface IChefManager
{
    public Task<List<ChefReadDto>> GetAllChefs();
    public Task<List<ChefReadDto>> GetTopChefs();
    public ChefReadDto? GetChef(string id);
    public bool UpdateChef(ChefUpdateDto chefDto);
    public Boolean DeleteChef(string id);
    //public string AddChef(ChefAddDto chefDto);
    public List<FeedbackDto> getAllchefFeedbacks(string id);
    public bool AddFeedback(FeedbackDto feedback);

}
