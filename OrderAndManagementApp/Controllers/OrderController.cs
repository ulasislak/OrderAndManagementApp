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

        public OrderController(IOrderService orderService, IMapper mapper, ICostumerService costumerService, IProductService productService)
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
            if (!ModelState.IsValid)
            {
                return View(orderVM);
            }

            // Customer information validation2131
            if (string.IsNullOrEmpty(orderVM.Costumer.Name) ||
                string.IsNullOrEmpty(orderVM.Costumer.LastName) ||
                string.IsNullOrEmpty(orderVM.Costumer.Address))
            {
                ModelState.AddModelError("", "Lütfen tüm müşteri bilgilerini doldurunuz.");
                return View(orderVM);
            }

            // Products validation
            if (orderVM.Products == null || !orderVM.Products.Any())
            {
                ModelState.AddModelError("", "Sepetinizde ürün bulunmamaktadır.");
                return View(orderVM);
            }

            // Create an order in the database
             await _orderService.AddOrder(_mapper.Map<OrderDto>(orderVM));

            // Redirect to order confirmation page
            return RedirectToAction("OrderConfirmation");


        }

        public IActionResult OrderConfirmation(string orderId)
        {
            return View(orderId);
        }

    }
}