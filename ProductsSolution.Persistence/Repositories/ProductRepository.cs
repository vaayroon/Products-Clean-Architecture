using ProductsSolution.Domain.Models;

using ProductsSolution.Persistence.Repositories.Interface;

namespace ProductsSolution.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    private List<Product> _products = new List<Product>(){
        new Product(){Id = 1, Name = "Product 1", Price = 10.00m},
        new Product(){Id = 2, Name = "Product 2", Price = 20.00m},
        new Product(){Id = 3, Name = "Product 3", Price = 30.00m},
        new Product(){Id = 4, Name = "Product 4", Price = 40.00m},
        new Product(){Id = 5, Name = "Product 5", Price = 50.00m},
        new Product(){Id = 6, Name = "Product 6", Price = 60.00m},
        new Product(){Id = 7, Name = "Product 7", Price = 70.00m},
        new Product(){Id = 8, Name = "Product 8", Price = 80.00m},
        new Product(){Id = 9, Name = "Product 9", Price = 90.00m},
        new Product(){Id = 10, Name = "Product 10", Price = 100.00m},
    };

    public List<Product> GetAllProducts()
    {
        return _products;
    }
    public Product GetProductById(int id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }

    public List<Product> AddProduct(Product product)
    {
        product.Id = _products.Count + 1;
        _products.Add(product);
        return _products;
    }
}
