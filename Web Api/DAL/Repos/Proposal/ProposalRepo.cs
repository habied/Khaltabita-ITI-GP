using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProposalRepo:IProposalRepo
    {
        public readonly FoodyContext FoodyContext;
        public ProposalRepo(FoodyContext foodyContext)
        {
            FoodyContext = foodyContext;
        }

        public void AddProposal(Proposal NewProposal)
        {
            NewProposal.Id = FoodyContext.Set<Proposal>()
                                         .OrderByDescending(x => x.Id)
                                         .Select(x => x.Id)
                                         .FirstOrDefault() + 1;
            FoodyContext.Set<Proposal>().Add(NewProposal);
        }

        public Proposal GetProposalById(int id)
        {
            return FoodyContext.Set<Proposal>().Where(x => x.Id == id).FirstOrDefault();
        }
        public void DeleteProposal(int id)
        {
            Proposal proposal=FoodyContext.Set<Proposal>().Where(x=>x.Id == id).FirstOrDefault();
            FoodyContext.Remove(proposal);
        }
        public int SaveChanges()
        {
            return FoodyContext.SaveChanges();
        }
    }
}
