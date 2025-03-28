using BusinnesLogic.AllDto.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLogic.AbstractServices
{
    public interface IProductService
    {
        Task AddProduct(ProductDto productDto);
        Task DeleteProduct(string Id);
        Task UpdateProduct(ProductDto productDto,string Id);
        Task<ProductDto> GetProductById(string Id);
        Task<List<ProductDto>> GetAllProduct();
        
    }
}
