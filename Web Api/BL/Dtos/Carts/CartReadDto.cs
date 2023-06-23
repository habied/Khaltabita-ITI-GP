using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos.Carts
{
    public class CartReadDto
    {
        public int Id { get; set; }
        public string UserMobile { get; set; } = null!;
        public string Location { get; set; } = null!;
        public int TotalPrice { get; set; }

        public string? ChefId { get; set; } = null!;
    }
}
