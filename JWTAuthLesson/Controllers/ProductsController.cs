using JWTAuthLesson.Entities;
using JWTAuthLesson.Services.ProductService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthLesson.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateProductAsync(ProductDTO product)
        {
            var result = await _productService.CreateProduct(product); 
            
            return Ok(result);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteProductAsync(int Id)
        {
            var result = await _productService.DeleteProduct(Id);

            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateProductAsync(ProductDTO product, int Id)
        {
            var result = await _productService.UpdateProduct(product, Id);

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetProductByIdAsync(int Id)
        {
            var result = await _productService.GetProductById(Id);

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllProductAsync()
        {
            var result = await _productService.GetAllProduct();

            return Ok(result);
        }
    }
}
