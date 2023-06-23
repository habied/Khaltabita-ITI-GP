using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos.Chefs
{
    public class ChefAddDto
    {

        public string ChefName { get; set; } = "";
        public string ChefAddress { get; set; } = "";
        public string ChefPass { get; set; } = "";
        public string? ChefPhoto { get; set; }

    }
}
