using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers.Proposal
{
    public interface IProposalManager
    {
        int AddProposal(ProposalAddDto NewProposal);
        void DeleteProposal(int id);
    }
}
