using BusinnesLogic.AllDto.ProductDto;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLogic.AllDto.OrderDto
{
    public class OrderDto:BaseDto
    {/////
        public DateTime OrderDate { get; set; }
        public string CostumerId { get; set; }
        public Costumer Costumer { get; set; }
        public List<Product> Products { get; set; }
       
    }
}
