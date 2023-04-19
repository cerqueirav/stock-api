using stock_api.Models;

namespace stock_api.Services
{
    public interface IProductService
    {
        public IEnumerable<Product> GetProductList();
        public Product? GetProductById(int id);
        public Product AddProduct(Product product);
        public Product UpdateProduct(Product product);
        public bool DeleteProduct(int Id);
    }
}
