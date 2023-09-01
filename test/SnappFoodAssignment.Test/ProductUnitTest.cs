using Microsoft.Extensions.Caching.Memory;
using Moq;
using SnappFoodAssignment.Api.Controllers;
using SnappFoodAssignment.Application.ApplicationServices.Products;
using SnappFoodAssignment.Application.Contract.Products.Dtos;
using SnappFoodAssignment.Application.Contract.UOW;
using SnappFoodAssignment.Domain.Orders;
using SnappFoodAssignment.Domain.Products;
using SnappFoodAssignment.Domain.Products.Exceptions;
using SnappFoodAssignment.Domain.Users;
using SnappFoodAssignment.Test.Helper;

namespace SnappFoodAssignment.Test;

public class ProductUnitTest
{
    private readonly Mock<IProductRepository> _productRepository;
    private readonly Mock<IOrderRepository> _orderRepository;
    private readonly Mock<IUserRepository> _userRepository;
    private readonly Mock<IUnitOfWork> _unitOfWork;
    private readonly ProductsController _productsController;
    public ProductUnitTest()
    {
        _productRepository = new Mock<IProductRepository>();
        _orderRepository = new Mock<IOrderRepository>();
        _userRepository = new Mock<IUserRepository>();
        _unitOfWork = new Mock<IUnitOfWork>();
        var productService = new ProductService(_productRepository.Object, new MemoryCache(new MemoryCacheOptions()
        {
            ExpirationScanFrequency = TimeSpan.FromSeconds(10)
        }), _userRepository.Object, _orderRepository.Object, _unitOfWork.Object);
        _unitOfWork.Setup(x => x.SaveAsync()).ReturnsAsync(true);
        _productsController = new ProductsController(productService);
    }

    [Fact]
    public async Task GetProduct_ShouldReturnProduct_WhenGetsProductId()
    {
        // Arrange
        var product = TestProductList.GetTestProductList().First();
        _productRepository.Setup(x => x.GetByIdAsync(product.Id)).ReturnsAsync(product);

        // Act
        var response = await _productsController.GetProduct(product.Id);

        
        // Assert
        Assert.NotNull(response);
        Assert.Equal(product?.Title, response?.Title);
        Assert.Equal(990, response?.Price);
    }
    

    [Fact]
    public async Task AddProduct_ShouldThrowException_WhenGetGreaterThan40CharactersAsProductTitle()
    {
        var product = new ProductDto()
        {
            Discount = 10,
            Price = 1000,
            Title = "Book1Book1Book1Book1Book1Book1Book1Book1Book1"
        };
        
        await Assert.ThrowsAsync<Title40CharactersLimitException>(() => _productsController.AddProduct(product));
    }
}