using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class PostReadDto
    {
        public int PostID { get; set; }

        public string Description { get; set; } = null!;

        public int? FromPrice { get; set; }

        public int? ToPrice { get; set; }

        public string? QuantityUnit { get; set; }

        public float Quantity { get; set; }

        public DateTime? PrepTime { get; set; }

        public DateTime Date { get; set; }

        public string UserId { get; set; }
        
        public string Username { get; set; }
        public string UserAddress { get; set; }


    }
}
