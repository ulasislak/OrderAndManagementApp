using System.Diagnostics;
using AutoMapper;
using BusinnesLogic.AbstractServices;
using Microsoft.AspNetCore.Mvc;
using OrderAndManagementApp.Models;
using OrderAndManagementApp.ViewModel;

namespace OrderAndManagementApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public HomeController(ILogger<HomeController> logger,IProductService productService,IMapper mapper)
    {
        _logger = logger;
        _productService = productService;
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpGet]
    public async Task<IActionResult> Products()
    {
        var GetAll = await _productService.GetAllProduct();
        var AllProduct = _mapper.Map<List<ProductVM>>(GetAll);
        return View(AllProduct);
    }

}
