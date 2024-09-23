using ProductAPI.Models;

namespace ProductAPI.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Product? GetProductById(int productId);
        Product CreateProduct(Product product);
        void DeleteProduct(int idProduct);
        Product UpdateProduct(Product product);
    }
}
