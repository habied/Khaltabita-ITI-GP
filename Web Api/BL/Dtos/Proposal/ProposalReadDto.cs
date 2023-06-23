using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ProposalReadDto
    {
        public int Id { get; set; }
        public int Price { get; set; }

        public string? Description { get; set; }

        public int PrepTimeMin { get; set; }

        public DateTime DatePosted { get; set; }

        public string? Media { get; set; }
        public string? ChefId { get; set; }
        public string? ChefName { get; set; }
        public decimal? ChefRating { get;set; }
        public string? ChefPhoto { set; get; }
    }
}
