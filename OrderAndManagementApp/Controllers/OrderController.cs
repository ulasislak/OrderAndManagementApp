using AutoMapper;
using BusinnesLogic.AbstractServices;
using BusinnesLogic.AllDto.CostumerDto;
using BusinnesLogic.AllDto.OrderDto;
using BusinnesLogic.AllDto.ProductDto;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using OrderAndManagementApp.ViewModel;

namespace OrderAndManagementApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        private readonly ICostumerService _costumerService;
        private readonly IProductService _productService;

        public OrderController(IOrderService orderService,IMapper mapper,ICostumerService costumerService,IProductService productService)
        {
            _orderService = orderService;
            _mapper = mapper;
            _costumerService = costumerService;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrder(string Id)
        {
            var getProductDto = await _productService.GetProductById(Id);  // ProductDto döndürüyor
            if (getProductDto == null)
            {
                return RedirectToAction("Products", "Home");
            }

            var order = new OrderVM
            {
                Products = new List<ProductDto> { getProductDto }  // ProductDto'yu listeye ekledik
            };

            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> GetOrder(OrderVM orderVM)
        {                                  
            // OrderDto oluştur
            var orderDto = new OrderDto
            {
                OrderDate = DateTime.Now, // Sipariş tarihi
                CostumerId = orderVM.CostumerId ?? Guid.NewGuid().ToString(), // CostumerId yoksa bir ID ata
                Costumer = _mapper.Map<Costumer>(orderVM.Costumer),
                Products = orderVM.Products.Select(p => new Product
                {
                    ProductName = p.ProductName,
                    Description = p.Description
                }).ToList()
            };

            await _orderService.AddOrder(orderDto);
            await _costumerService.AddCostumer(_mapper.Map<CostumerDto>(orderVM.Costumer));
            return RedirectToAction("OrderSuccess");
        }
    }
}