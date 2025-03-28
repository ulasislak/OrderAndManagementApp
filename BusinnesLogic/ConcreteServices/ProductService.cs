using AutoMapper;
using BusinnesLogic.AbstractServices;
using BusinnesLogic.AllDto.ProductDto;
using DataAccess.AbstractRepository;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLogic.ConcreteServices
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _genericRepository;
        private readonly IMapper _mapper;

        public ProductService(IGenericRepository<Product> genericRepository,IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }
        public async Task AddProduct(ProductDto productDto)
        {
            await _genericRepository.AddAsync(_mapper.Map<Product>(productDto));
        }

        public async Task DeleteProduct(string Id)
        {
            await _genericRepository.DeleteAsync(Id);
        }

        public async Task<List<ProductDto>> GetAllProduct()
        {
            return _mapper.Map<List<ProductDto>>(await _genericRepository.GetAllAsync());
        }

        public async Task<ProductDto> GetProductById(string Id)
        {
            await _genericRepository.GetByIdAsync(Id);
            return null;
        }

        public async Task UpdateProduct(ProductDto productDto, string Id)
        {
            await _genericRepository.UpdateAsync(_mapper.Map<Product>(productDto),Id); 
        }
    }
}
