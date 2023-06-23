using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Chefs
{
    public class ChefRepo : IChefRepo
    {
        private readonly FoodyContext _foodyContext;
        public ChefRepo(FoodyContext foodyContext)
        {
            _foodyContext = foodyContext;
        }
        public bool DeleteChef(string id)
        {
            Chef? chef = _foodyContext.Set<Chef>().FirstOrDefault(x => x.Id == id);
            if (chef == null) { return false; }
            _foodyContext.Set<Chef>().Remove(chef);
            return true;
        }
        public async Task<IEnumerable<Chef>> GetAllChefs()
        {
            return await _foodyContext.Set<Chef>().ToListAsync();
        }
        public async Task<IEnumerable<Chef>> GetTopChefs()
        {
            return await _foodyContext.Set<Chef>().OrderByDescending(c => c.Rating).Take(10).ToListAsync();
        }

        public Chef? GetChef(string id)
        {
            Chef? chef = _foodyContext.Set<Chef>().FirstOrDefault(x => x.Id == id);
            if (chef == null) { return null; }
            return chef;
        }
        public List<Feedback> getAllchefFeedbacks(string id)
        {
            return _foodyContext.Set<Feedback>().Include(u => u.User).Where(f => f.ChefId == id).ToList();
        }
        public bool AddFeedback(Feedback feedback)
        {
           DateTime lastReviewTime = _foodyContext.Set<Feedback>()
                .Where(u => u.UserId == feedback.UserId && u.ChefId== feedback.ChefId)
                .Select(d => d.Date).FirstOrDefault();
            if (DateTime.Now.Date == lastReviewTime.Date) { return false; }
            _foodyContext.Set<Feedback>().Add(feedback);
            return true;
        }

        public int SaveChanges()
        {
            return _foodyContext.SaveChanges();
        }

        public void UpdateChef(Chef chef)
        {

        }
    }
}
