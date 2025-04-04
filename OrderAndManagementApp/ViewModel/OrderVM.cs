using DataAccess.Entities;

namespace OrderAndManagementApp.ViewModel
{
    public class OrderVM:BaseVM
    {
        public string ProductName { get; set; }
        public DateTime OrderDate { get; set; }
        public string CostumerId { get; set; }
        public Costumer Costumer { get; set; }
        public List<Product> Products { get; set; }

    }
}
