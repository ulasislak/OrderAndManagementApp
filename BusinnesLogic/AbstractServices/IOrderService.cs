using BusinnesLogic.AllDto.OrderDto;
using BusinnesLogic.AllDto.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLogic.AbstractServices
{
    public interface IOrderService
    {
        Task AddOrder(OrderDto orderDto);
        Task DeleteOrder(string Id);
        Task UpdateOrder(OrderDto orderDto, string Id);
        Task<OrderDto> GetOrderById(string Id);
        Task<List<OrderDto>> GetAllOrder();
    }
}