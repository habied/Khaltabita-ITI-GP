using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos.Post
{
    public class AcceptedOrderAddDto
    {

        public string Description { get; set; } = null!;

        public int FinalPrice { get; set; }

        public string? QuantityUnit { get; set; }

        public int Quantity { get; set; }

        public DateTime PrepTime { get; set; }

        public string? AdditionalInfo { get; set; }

        public int PostId { get; set; }

        public int ProposalId { get; set; }

        public string ChefId { get; set; } = string.Empty;

        public string UserId { get; set; } = "";

    }
}
