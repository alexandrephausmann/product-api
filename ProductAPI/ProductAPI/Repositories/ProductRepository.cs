using Dapper;
using ProductAPI.Models;
using ProductAPI.Repositories.Interfaces;
using System.Data;

namespace ProductAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _dbConnection;

        public ProductRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Product CreateProduct(Product product)
        {
            var SqlCommand = @"
                    INSERT INTO product (description, value, notes) 
                    VALUES (@description, @value, @notes);
                    SELECT CAST(SCOPE_IDENTITY() AS int);";

            var newId = _dbConnection.QuerySingle<int>(SqlCommand, product);
            product.Id = newId;

            return product;
        }

        public void DeleteProduct(int idProduct)
        {
            var product = GetProductById(idProduct);

            if (product is null || product.Id.Equals(0))
                return;

             var SqlCommand = @"
                    DELETE FROM product WHERE id = @idProduct"; 

            _dbConnection.Execute(SqlCommand, new { idProduct = product.Id });
        }

        public Product? GetProductById(int productId)
        {
            var comandoSql = @"SELECT * FROM product WHERE id = @ID";
            return _dbConnection.Query<Product>(comandoSql, new { ID = productId }).SingleOrDefault();
        }

        public IEnumerable<Product> GetProducts()
        {
            var comandoSql = @"SELECT * FROM product";
            return _dbConnection.Query<Product>(comandoSql).ToArray();
        }

        public Product UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
