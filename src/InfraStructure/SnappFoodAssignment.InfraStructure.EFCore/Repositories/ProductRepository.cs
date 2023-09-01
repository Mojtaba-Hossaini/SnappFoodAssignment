using Microsoft.EntityFrameworkCore;
using SnappFoodAssignment.Domain.Products.Exceptions;
using SnappFoodAssignment.InfraStructure.EFCore.Extensions;

namespace SnappFoodAssignment.InfraStructure.EFCore.Repositories;
public class ProductRepository : Domain.Products.IProductRepository
{
    private readonly SnappFoodAssignmentDbContext _dbContext;

    public ProductRepository(SnappFoodAssignmentDbContext dbContext)
    {
        this._dbContext = dbContext;
    }
    public async Task<Domain.Products.Product?> GetByIdAsync(long id)
    {
        var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        return product is null ? null : product.ToProductDomain();
    }

    public async Task<bool> ExistSsync(string title)
    {
        return await _dbContext.Products.AnyAsync(c => c.Title == title);
    }

    public async Task AddAsync(Domain.Products.Product product)
    {
        await _dbContext.AddAsync(product.ToProductDataModel());
    }
    public async Task UpdateAsync(Domain.Products.Product product)
    {
        var oldProduct = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
        if (oldProduct == null) throw new InvalidOperationException("product not found");
        oldProduct.Title = product.Title;
        oldProduct.Price = product.Price;
        oldProduct.Discount = product.Discount;
        oldProduct.InventoryCount = product.InventoryCount;
    }
}
