using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Product:BaseClass
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public IFormFile PhotoUrl { get; set; }

        public string PhotoUrlPath { get; set; }
        public int Piece { get; set; }
    }
}
