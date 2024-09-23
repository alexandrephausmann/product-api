using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Enums;
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
        /// <summary>
        /// Get all products from Fiap marketplace
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetProducts")]                
        [Authorize(Roles = SystemRoleDescription.Administrator)]
        public IActionResult GetProducts()
        {
            var products = _productService.GetProducts();
            return Ok(products);
        }

        /// <summary>
        /// Get a product from Fiap marketplace by ID
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        /// <response code="204">Fail to find the product</response>
        /// <response code="200">Success</response>
        [HttpGet("{productId}")]
        [Authorize()]
        public IActionResult GetProductById(int productId)
        {
            var product = _productService.GetProductById(productId);
            if(product == null) { 
                return NoContent();
            }
            return Ok(product);
        }

        /// <summary>
        /// Create a new product in Fiap marketplace
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost("CreateProduct")]
        [Authorize(Roles = SystemRoleDescription.Administrator)]
        public IActionResult CreateProduct(Product product)
        {
            var productCreated = _productService.CreateProduct(product);
            return Created("", productCreated);            
        }

        /// <summary>
        /// Delete a product in Fiap marketplace
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        /// <response code="204">Success</response>
        [HttpDelete("DeleteProduct/{productId}")]
        [Authorize(Roles = SystemRoleDescription.Administrator)]
        public IActionResult DeleteProduct(int productId)
        {
            _productService.DeleteProduct(productId);
            return NoContent();
        }

        /// <summary>
        /// Update a product in Fiap marketplace
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        /// <response code="204">Success</response>
        
        [HttpPut("/UpdateProduct")]
        [Authorize(Roles = SystemRoleDescription.Administrator)]
        public IActionResult UpdateProduct(Product product)
        {
            _productService.UpdateProduct(product);
            return NoContent();
        }
    }
}
