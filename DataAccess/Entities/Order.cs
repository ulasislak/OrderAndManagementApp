using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Order:BaseClass
    {
        public string ProductName { get; set; }
        public DateTime OrderDate { get; set; }
        public string CostumerId { get; set; }
        public Costumer Costumer { get; set; }
        public List<Product> Products { get; set; }
    }
}