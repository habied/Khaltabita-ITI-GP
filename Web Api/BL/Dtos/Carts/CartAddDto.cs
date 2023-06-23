using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos.Carts
{
    public class CartAddDto
    {
        public string UserMobile { get; set; } = null!;

        public string Location { get; set; } = null!;

        //public DateTime DeliveryDate { get; set; }

        public int TotalPrice { get; set; }

        public string ChefId { get; set; } = null!;
    }
}
