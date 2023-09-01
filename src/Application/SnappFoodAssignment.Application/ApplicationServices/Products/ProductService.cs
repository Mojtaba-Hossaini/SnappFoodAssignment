using Microsoft.Extensions.Caching.Memory;
using SnappFoodAssignment.Application.Contract.Products;
using SnappFoodAssignment.Application.Contract.Products.Dtos;
using SnappFoodAssignment.Application.Contract.UOW;
using SnappFoodAssignment.Application.Extensions;
using SnappFoodAssignment.Domain.GeneralExceptions;
using SnappFoodAssignment.Domain.Orders;
using SnappFoodAssignment.Domain.Products;
using SnappFoodAssignment.Domain.Products.Exceptions;
using SnappFoodAssignment.Domain.Users;

namespace SnappFoodAssignment.Application.ApplicationServices.Products;
public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMemoryCache _memoryCache;
    private readonly IUserRepository _userRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IProductRepository productRepository, IMemoryCache memoryCache, 
        IUserRepository userRepository, IOrderRepository orderRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _memoryCache = memoryCache;
        _userRepository = userRepository;
        _orderRepository = orderRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<ProductDto> GetProductAsync(long id)
    {
        var product = await _memoryCache.GetOrCreateAsync($"{nameof(Product)}_{id}", async c =>
        {
            c.SlidingExpiration = TimeSpan.FromSeconds(30);
            return await _productRepository.GetByIdAsync(id) ?? null;
        });
        if (product is null) throw new NotFoundBusinessException();
        return product.ToProductDto();
    }

    public async Task AddProductAsync(ProductDto request)
    {
        if(await _productRepository.ExistSsync(request.Title))
            throw new DuplicateProductBusinessException();
        await _productRepository.AddAsync(request.ToCoreDomain());
        await _unitOfWork.SaveAsync();
    }

    public async Task<bool> OrderProductAsync(long productId, long userId, int quantity)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        var product = await _productRepository.GetByIdAsync(productId);
        if (product is null) throw new NotFoundBusinessException();
        if (product.InventoryCount < quantity)
            throw new InventoryCountOutOfSaleBusinessException();
        var order = new Order
        {
            ProductId = product.Id,
            UserId = user.Id,
            OrderDate = DateTime.UtcNow,
        };
        await _orderRepository.AddAsync(order);
        product.UpdateInventoryCount(-quantity);
        await _productRepository.UpdateAsync(product);
        return await _unitOfWork.SaveAsync();
    }
    public async Task UpdateInventoryCountAsync(long productId, int quantity)
    {
        var product = await _productRepository.GetByIdAsync(productId);
        if (product is null) throw new NotFoundBusinessException();
        product.UpdateInventoryCount(quantity);
        await _productRepository.UpdateAsync(product);
        await _unitOfWork.SaveAsync();
    }
}
