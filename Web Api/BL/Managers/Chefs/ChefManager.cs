using BL.Dtos.Chefs;
using DAL.Models;
using DAL.Repos.Chefs;

namespace BL.Managers.Chefs;

public class ChefManager : IChefManager
{
    private readonly IChefRepo _chefRepo;
    public ChefManager(IChefRepo chefRepo)
    {
        _chefRepo = chefRepo;
    }
    public List<FeedbackDto> getAllchefFeedbacks(string id)
    {
        List<Feedback> feedbacks = _chefRepo.getAllchefFeedbacks(id);
        return feedbacks.Select(c => new FeedbackDto
        {
            userId = c.UserId,
            chefId = c.ChefId,
            review = c.Review,
            rating = c.Rating,
            date = c.Date.ToString("yyyy-MM-dd"),
            UserName = c.User.Name,
        }).ToList();
    }

    public bool AddFeedback(FeedbackDto feedback)
    {
        Feedback chffeedback = new Feedback
        {
            UserId = feedback.userId,
            ChefId = feedback.chefId,
            Review = feedback.review,
            Rating = feedback.rating,
            Date = DateTime.Now.Date,
        };
        bool CanWeAddReview = _chefRepo.AddFeedback(chffeedback);
        if (!CanWeAddReview) { return false; }
        _chefRepo.SaveChanges();
        return true;
    }


    public bool DeleteChef(string id)
    {
        bool deleted = _chefRepo.DeleteChef(id);
        if (deleted == true)
        {
            _chefRepo.SaveChanges();
        }
        return deleted;
    }

    public async Task<List<ChefReadDto>> GetAllChefs()
    {
        IEnumerable<Chef> chefs = await _chefRepo.GetAllChefs();
        return chefs.Select(d => new ChefReadDto
        {
            ChefName = d.Name,
            ChefAddress = d.Address,
            ChefId = d.Id,
            //ChefRating = d.Rating,
            ChefPhoto = d.Media,
        }).ToList();
    }
    public async Task<List<ChefReadDto>> GetTopChefs()
    {
        IEnumerable<Chef> chefs = await _chefRepo.GetTopChefs();
        return chefs.Select(d => new ChefReadDto
        {
            ChefName = d.Name,
            ChefAddress = d.Address,
            ChefId = d.Id,
            ChefRating = d.Rating,
            ChefPhoto = d.Media,
        }).ToList();
    }


    public ChefReadDto? GetChef(string id)
    {
        Chef? chef = _chefRepo.GetChef(id);
        if (chef != null)
        {
            return new ChefReadDto
            {
                ChefName = chef.Name,
                ChefAddress = chef.Address,
                ChefId = chef.Id,
                ChefRating = chef.Rating,
                ChefPhoto = chef.Media,
            };
        }
        return null;
    }

    public bool UpdateChef(ChefUpdateDto chefDto)
    {
        Chef? chef = _chefRepo.GetChef(chefDto.ChefId);
        if (chef != null)
        {
            chef.Name = chefDto.ChefName;
            chef.Address = chefDto.ChefAddress;
            _chefRepo.UpdateChef(chef);
            _chefRepo.SaveChanges();
            return true;
        }
        return false;

    }
}
