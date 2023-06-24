using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL
{
    public interface IProposalRepo
    {
        void AddProposal(Proposal NewProposal);
        Proposal GetProposalById(int id);
        void DeleteProposal(int id);
        int SaveChanges();
    }
}
