namespace SnappFoodAssignment.Domain.Products;
public interface IProductRepository
{
    Task<Product?> GetByIdAsync(long id);
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task<bool> ExistSsync(string title);
}