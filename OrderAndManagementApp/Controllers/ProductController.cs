using AutoMapper;
using BusinnesLogic.AbstractServices;
using BusinnesLogic.AllDto.ProductDto;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
            if (productVM.PhotoUrl != null && productVM.PhotoUrl.Length > 0)
            {
                // Wwwroot klasörü altında images klasörü oluştur
                string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

                // Klasörü oluştur (eğer yoksa)
                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }

                // Benzersiz dosya adı oluştur
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + productVM.PhotoUrl.FileName;
                string filePath = Path.Combine(uploadFolder, uniqueFileName);

                // Dosyayı kaydet
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await productVM.PhotoUrl.CopyToAsync(fileStream);
                }

                // DTO'ya dosya yolunu kaydet
                var productDto = _mapper.Map<ProductDto>(productVM);
                productDto.PhotoUrlPath = "/images/" + uniqueFileName;

               
                var addedProduct = _productService.AddProduct(productDto);

                if (addedProduct != null)
                {
                    return RedirectToAction("AllProduct", "Product");
                }
            }

            return View(productVM);
        }

        [HttpGet]
        public async Task<IActionResult> AllProduct()
        {
            var allProduct = _mapper.Map<List<ProductVM>>(await _productService.GetAllProduct());            
            return View(allProduct);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string Id)
        {          
            await _productService.DeleteProduct(Id);
            return RedirectToAction("AllProduct", "Product");
        }

        [HttpGet]
        public async Task<IActionResult> Update(string Id)
        {
            var product =await _productService.GetProductById(Id.ToString());
            if (product == null)
            {
                return RedirectToAction("AllProduct", "Product");
            }
            var productVM = _mapper.Map<ProductVM>(product); 
            return View(productVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductVM productVM,string Id)
        {
            await _productService.UpdateProduct(_mapper.Map<ProductDto>(productVM), Id);
            return RedirectToAction("AllProduct","Product");            
        }
    }
}