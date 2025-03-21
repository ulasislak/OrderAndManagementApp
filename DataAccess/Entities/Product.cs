using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Product:BaseClass
    {
        public string ProductName { get; set; }
        public int Piece { get; set; }
    }
}
