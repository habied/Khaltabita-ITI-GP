using BL.Managers.Proposal;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ProposalManager:IProposalManager
    {
        public readonly IProposalRepo _proposalRepo;
        public ProposalManager(IProposalRepo proposalRepo) {
            _proposalRepo= proposalRepo;
        }

        public int AddProposal(ProposalAddDto NewProposalDto)
        {
            Proposal NewProposal = new Proposal
            {
                Description = NewProposalDto.Description,
                Price = NewProposalDto.Price,
                PostId = NewProposalDto.PostId,
                ChefId = NewProposalDto.ChefId
            };
            _proposalRepo.AddProposal(NewProposal);
            _proposalRepo.SaveChanges();
            return NewProposal.Id;
        }

        public void DeleteProposal(int id)
        {
            _proposalRepo.DeleteProposal(id);
            _proposalRepo.SaveChanges();
        }
    }
}
