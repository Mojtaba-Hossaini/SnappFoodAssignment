using SnappFoodAssignment.Application.Contract.Products.Dtos;

namespace SnappFoodAssignment.Application.Contract.Products;
public interface IProductService
{
    Task AddProductAsync(ProductDto productRequest);
    Task UpdateInventoryCountAsync(long productId, int quantity);
    Task<ProductDto> GetProductAsync(long id);
    Task<bool> OrderProductAsync(long productId, long userId, int quantity);
}