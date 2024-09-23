using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;
using ProductAPI.Services.Interfaces;

namespace ProductAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger,IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }
        
        [HttpGet("GetProducts")]
        public IActionResult GetProducts()
        {
            var products = _productService.GetProducts();
            return Ok(products);
        }
        
        [HttpGet("{productId}")]
        public IActionResult GetProductById(int productId)
        {
            var product = _productService.GetProductById(productId);
            if(product == null) { 
                return NoContent();
            }
            return Ok(product);
        }

        [HttpPost("CreateProduct")]
        public IActionResult CreateProduct(Product product)
        {
            var productCreated = _productService.CreateProduct(product);
            return Created("", productCreated);            
        }

        [HttpDelete("DeleteProduct/{productId}")]
        public IActionResult DeleteProduct(int productId)
        {
            _productService.DeleteProduct(productId);
            return NoContent();
        }
        /*
        [HttpPut(Name = "UpdateProduct")]
        public IEnumerable<Product> UpdateProduct(Product product)
        {

        }*/
    }
}
