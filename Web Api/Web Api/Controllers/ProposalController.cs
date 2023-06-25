using BL;
using BL.Managers.Proposal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProposalController : ControllerBase
    {
        public readonly IProposalManager _proposalManager;
        public ProposalController(IProposalManager proposalManager)
        {
            _proposalManager= proposalManager;
        }
        [HttpPost]
        public ActionResult AddProposal(ProposalAddDto NewProposal)
        {
            int NewId=_proposalManager.AddProposal(NewProposal);
            return Ok(NewId);
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteProposal(int id)
        {
            _proposalManager.DeleteProposal(id);
            return Ok();
        }

    }
}
