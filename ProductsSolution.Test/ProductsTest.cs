using Xunit;
using Moq;
using ProductsSolution.Presentation.Controllers;
using ProductsSolution.Persistence.Repositories;
using ProductsSolution.Persistence.Repositories.Interface;
using ProductsSolution.Presentation.Models;
using ProductsSolution.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProductsSolution.Test;

public class ProductsTest
{
    [Fact]
    public void GetProductById_ReturnsProductDto_WhenProductExists()
    {
        // Arrange
        var productId = 1;
        var mockProductRepository = new Mock<IProductRepository>();
        mockProductRepository.Setup(repo => repo.GetProductById(productId)).Returns(new Product(){Id = 1, Name = "Product 1", Price = 10});
        var controller = new ProductsController(mockProductRepository.Object);

        // Act
        var result = controller.GetById(productId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<ProductDto>(okResult.Value);
        Assert.Equal(1, returnValue.Id);
        Assert.Equal("Product 1", returnValue.Name);
        Assert.Equal(10, returnValue.Price);
    }

    [Fact]
    public void AddProduct_ReturnsListProductDtoWithNewProduct_WhenProductAdded()
    {
        // Arrange
        var mockProductRepository = new Mock<IProductRepository>();
        mockProductRepository.Setup(repo => repo.AddProduct(It.IsAny<Product>())).Returns(new List<Product>(){
            new Product(){Id = 1, Name = "Product 1", Price = 10},
            new Product(){Id = 2, Name = "Product 2", Price = 20},
            new Product(){Id = 3, Name = "Product 3", Price = 30},
            new Product(){Id = 4, Name = "Product 4", Price = 40},
            new Product(){Id = 5, Name = "Product 5", Price = 50},
            new Product(){Id = 6, Name = "Product 6", Price = 60},
            new Product(){Id = 7, Name = "Product 7", Price = 70},
            new Product(){Id = 8, Name = "Product 8", Price = 80},
            new Product(){Id = 9, Name = "Product 9", Price = 90},
            new Product(){Id = 10, Name = "Product 10", Price = 100},
            new Product(){Id = 11, Name = "Product 11", Price = 110},
        });
        var controller = new ProductsController(mockProductRepository.Object);
        var newProduct = new ProductDto(){Name = "Product 11", Price = 110};

        // Act
        var result = controller.AddProduct(newProduct);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<List<ProductDto>>(okResult.Value);
        Assert.Equal(11, returnValue.Count);
        Assert.Equal(11, returnValue[10].Id);
        Assert.Equal("Product 11", returnValue[10].Name);
        Assert.Equal(110, returnValue[10].Price);
    }
}