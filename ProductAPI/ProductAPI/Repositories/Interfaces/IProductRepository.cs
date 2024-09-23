using ProductAPI.Models;

namespace ProductAPI.Repositories.Interfaces
{
    public interface IProductRepository
    {
        /// <summary>
        /// Get all products from the database.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Product> GetProducts();
        /// <summary>
        /// Get product from database based in the product Id.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns>Product</returns>
        Product? GetProductById(int productId);

        /// <summary>
        /// Create a product for FIAP Marketplace.
        /// </summary>
        /// <param name="product">Product</param>
        /// <returns>Product with updated Id.</returns>
        Product CreateProduct(Product product);

        /// <summary>
        /// Delete Product by Id.
        /// </summary>
        /// <param name="idProduct">Database product Id.</param>
        void DeleteProduct(int idProduct);
        /// <summary>
        /// Update the entire product on database.
        /// </summary>
        /// <param name="product"></param>
        void UpdateProduct(Product product);
    }
}
