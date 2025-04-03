using AutoMapper;
using BusinnesLogic.AbstractServices;
using BusinnesLogic.AllDto.OrderDto;
using DataAccess.AbstractRepository;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLogic.ConcreteServices
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order> _genericRepository;
        private readonly IMapper _mapper;

        public OrderService(IGenericRepository<Order> genericRepository,IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }
        public async Task AddOrder(OrderDto orderDto)
        {
            await _genericRepository.AddAsync(_mapper.Map<Order>(orderDto));
        }

        public async Task DeleteOrder(string Id)
        {
            await _genericRepository.DeleteAsync(Id);
        }

        public async Task<List<OrderDto>> GetAllOrder()
        {
            return _mapper.Map<List<OrderDto>>(await _genericRepository.GetAllAsync());
        }

        public async Task<OrderDto> GetOrderById(string id)
        {
            var GetId=await _genericRepository.GetByIdAsync(id);
            return _mapper.Map<OrderDto>(GetId);
        }

        public async Task UpdateOrder(OrderDto orderDto, string Id)
        {
            await _genericRepository.UpdateAsync(_mapper.Map<Order>(orderDto), Id);
        }
    }
}