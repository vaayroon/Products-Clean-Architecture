using ProductsSolution.Persistence.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using ProductsSolution.Domain.Models;
using ProductsSolution.Presentation.Models;

namespace ProductsSolution.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController  : ControllerBase
{
    private readonly IProductRepository _productRepository;


    public ProductsController (IProductRepository productRepository)
    {
        _productRepository = productRepository;

    }

    [HttpGet]
    [Route("GetAll")]
    public IActionResult GetAll()
    {
        List<Product> products = _productRepository.GetAllProducts();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        Product product = _productRepository.GetProductById(id);
        if (product == null)
        {
            return NotFound();
        }
        ProductDto productDto = new(){
            Id = product.Id,
            Name = product.Name,
            Price = product.Price
        };
        return Ok(productDto);
    }

    [HttpPost]
    public IActionResult AddProduct(ProductDto product)
    {
        Product newProduct = new(){
            Name = product.Name,
            Price = product.Price
        };
        var resultProducts = _productRepository.AddProduct(newProduct);
        var productsToReturn = resultProducts.Select(p => new ProductDto(){
            Id = p.Id,
            Name = p.Name,
            Price = p.Price
        }).ToList();
        return Ok(productsToReturn);
    }

}
