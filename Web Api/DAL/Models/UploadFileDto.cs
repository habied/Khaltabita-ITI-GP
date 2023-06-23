using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class UploadFileDto
    {
        public string URL { get; set; }

        public UploadFileDto (string url = "")
        {
           URL=url;

        }
    }
}
