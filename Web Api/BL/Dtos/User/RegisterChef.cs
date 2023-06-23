using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos.User
{
    public class RegisterChef
    {
        public string Mobile { get; set; } = null!;

        public string Name { get; set; } = string.Empty;

        public string? Email { get; set; }

        public string Password { get; set; } = null!;

        public string Media { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;


    }
}
