using BL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class PostWithProposalsDto
    {
        public PostReadDto postReadDto { set; get; }
        public List<ProposalReadDto> ProposalsDto { get; set; } = new List<ProposalReadDto>();
    }
}
