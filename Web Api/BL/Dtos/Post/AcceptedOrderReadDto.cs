using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AcceptedOrderReadDto
    {

        public int Id { get; set; }

        public string Description { get; set; } = null!;

        public int FinalPrice { get; set; }

        public string? QuantityUnit { get; set; }

        public int Quantity { get; set; }

        public DateTime PreparationTime_min { get; set; }

        public DateTime Date { get; set; }

        public string? AdditionalInfo { get; set; }

        public string ChefId { get; set; } = string.Empty;

        public string UserId { get; set; } = "";

    }
}
