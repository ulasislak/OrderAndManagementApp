using System.ComponentModel.DataAnnotations.Schema;

namespace OrderAndManagementApp.ViewModel
{
    public class ProductVM:BaseVM
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public IFormFile PhotoUrl { get; set; }
        public string PhotoUrlPath { get; set; }
        public int Piece { get; set; }
    }
}
