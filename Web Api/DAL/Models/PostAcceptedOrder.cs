using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class PostAcceptedOrder
    {
        
        public int Id { get; set; }

        public string Description { get; set; } = null!;

        public int FinalPrice { get; set; }

        public string? QuantityUnit { get; set; }

        public int Quantity { get; set; }

        public DateTime DeliveryDate{ get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public string? AdditionalInfo { get; set; }

        public int PostId { get; set; }

        public int ProposalId { get; set; }

        public string ChefId { get; set; } = string.Empty;

        public string UserId { get; set; } = "";

        public virtual User User { get; set; } = null!;

        public virtual Chef Chef { get; set; } = null!;

        public virtual Post Post { get; set; } = null!;
        public virtual Proposal Proposal { get; set; } = null!;

    }
}
