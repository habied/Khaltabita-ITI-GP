﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos.Menu
{
    public class AddMenuItemDto
    {
        public string? Name { set; get; }
        public string? Media { get; set; }
        public string? Category { get; set; }
        public string? Description { set; get; }
        public int UnitPrice { set; get; }
        public int? PrepTime { set; get; }
        public string? Availability { set; get; }
        public string? ChefId { set; get; }
    }
}
