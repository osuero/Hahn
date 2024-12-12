using Hahn_OctavioSueroBackEnd.Application.Services;
using Hahn_OctavioSueroBackEnd.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Hahn_OctavioSueroBackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            await _productService.AddProductAsync(product);
            return Ok(product);
        }
    }
}
