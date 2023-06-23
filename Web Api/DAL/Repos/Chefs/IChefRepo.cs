using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Chefs
{
    public interface IChefRepo
    {
        public Task<IEnumerable<Chef>> GetAllChefs();
        public Task<IEnumerable<Chef>> GetTopChefs();
        public List<Feedback> getAllchefFeedbacks(string id);
        public bool AddFeedback(Feedback feedback);
        public Chef? GetChef(string id);
        public void UpdateChef(Chef chef);
        public Boolean DeleteChef(string id);
        //public void AddChef(Chef chef);
        int SaveChanges();
    }
}
