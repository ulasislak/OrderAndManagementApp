using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class CustomerProduct:BaseClass
    {
        public string CustomerId { get; set; }
        public Costumer Costumers { get; set; }

        public string ProductId { get; set; }
        public Product Product { get; set; }
       
    }
}
