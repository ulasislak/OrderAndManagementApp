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

        public OrderController(IOrderService orderService,IMapper mapper,ICostumerService costumerService)
        {
            _orderService = orderService;
            _mapper = mapper;
            _costumerService = costumerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrder(string id)
        {
            var GetId = await _orderService.GetOrderById(id);
            if (GetId==null)
            {
                return RedirectToAction("Products","Home");
            }
            var Order = _mapper.Map<OrderVM>(GetId);
            return View(Order);
        }

        [HttpPost]
        public async Task<IActionResult> GetOrder(CostumerVM costumerVM)
        {
            return View();
        }


    }
}
