using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Costumer:BaseClass
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public List<Order> Orders { get; set; }
    }
}
