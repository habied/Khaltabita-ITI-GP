using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos.Post
{
    public class PostAddDto
    {

        public required string Description { get; set; } = null!;

        public required int? FromPrice { get; set; }

        public required int? ToPrice { get; set; }

        public required string? QuantityUnit { get; set; }

        public required float Quantity { get; set; }

        public required DateTime? PrepTime { get; set; }

        public required string UserId { get; set; } = "";
    }
}
