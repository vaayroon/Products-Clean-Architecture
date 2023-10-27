using ProductsSolution.Domain.Models;

namespace ProductsSolution.Persistence.Repositories.Interface;

public interface IProductRepository
{
    Product GetProductById(int id);
    List<Product> AddProduct(Product product);
    List<Product> GetAllProducts();
}
