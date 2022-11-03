using Application.Services;
using Entity.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {           
            
            var result = _productService.GetProducts();
            return View(result);
        }
        
    }
}