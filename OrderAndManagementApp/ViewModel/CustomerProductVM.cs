using DataAccess.Entities;

namespace OrderAndManagementApp.ViewModel
{
    public class CustomerProductVM:BaseVM
    {
        public string CustomerId { get; set; }
        public Costumer Costumers { get; set; }

        public string ProductId { get; set; }
        public Product Product { get; set; }
    }
}
