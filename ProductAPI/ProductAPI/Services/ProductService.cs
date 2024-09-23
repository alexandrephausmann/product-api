using ProductAPI.Models;
using ProductAPI.Repositories.Interfaces;
using ProductAPI.Services.Interfaces;

namespace ProductAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Product CreateProduct(Product product)
        {
            return _productRepository.CreateProduct(product);
        }

        public void DeleteProduct(int idProduct)
        {
           _productRepository.DeleteProduct(idProduct);
        }

        public Product? GetProductById(int productId)
        {
            return _productRepository.GetProductById(productId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public void UpdateProduct(Product product)
        {
            _productRepository.UpdateProduct(product);
        }
    }
}
