using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Owner:BaseClass
    {
        public string Mail { get; set; }
        public string Password { get; set; }
    }
}