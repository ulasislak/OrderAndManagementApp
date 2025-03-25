using DataAccess.Entities;

namespace OrderAndManagementApp.ViewModel
{
    public class CostumerVM:BaseVM
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public List<Order> Orders { get; set; }
    }
}
