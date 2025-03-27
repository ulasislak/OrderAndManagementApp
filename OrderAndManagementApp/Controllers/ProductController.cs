using AutoMapper;
using BusinnesLogic.AbstractServices;
using BusinnesLogic.AllDto.ProductDto;
using Microsoft.AspNetCore.Mvc;
using OrderAndManagementApp.ViewModel;

namespace OrderAndManagementApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService,IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductVM productVM)
        {           
            var productDto = _mapper.Map<ProductDto>(productVM);

            if (productVM.PhotoUrl != null && productVM.PhotoUrl.Length > 0)
            {               
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", productVM.PhotoUrl.FileName);
               
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await productVM.PhotoUrl.CopyToAsync(stream);
                }
               
                productDto.PhotoUrlPath = "/images/" + productVM.PhotoUrl.FileName;
            }            
            var addedProduct = _productService.AddProduct(productDto);
           
            if (addedProduct != null)
            {
                return RedirectToAction("AllProduct", "Product");
            }            
            return View();
        }


        [HttpGet]
        public IActionResult AllProduct()
        {
            return View();
        }

    }
}
