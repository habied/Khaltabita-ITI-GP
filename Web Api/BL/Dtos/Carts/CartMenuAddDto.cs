using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos.Carts
{
    public class CartMenuAddDto
    {
        public int MenuItemId { get; set; }

        public int CartId { get; set; }

        public int Quantity { get; set; }

        public int TotalItemPrice { get; set; }
    }
}
