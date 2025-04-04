using AutoMapper;
using BusinnesLogic.AbstractServices;
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
            var GetProductId = _productService.GetProductById(Id);
            if (GetProductId==null)
            {
                return RedirectToAction("Products","Home");
            }
            var Product = _mapper.Map<ProductVM>(GetProductId);
            return View(Product);
        }

        [HttpPost]
        public async Task<IActionResult> GetOrder(CostumerVM costumerVM)
        {
            return View();
        }
    }
}