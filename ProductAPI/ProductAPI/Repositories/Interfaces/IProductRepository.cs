using ProductAPI.Models;

namespace ProductAPI.Repositories.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product? GetProductById(int productId);
        Product CreateProduct(Product product);
        void DeleteProduct(int idProduct);
        Product UpdateProduct(Product product);
    }
}
