using Microsoft.EntityFrameworkCore;
using SnappFoodAssignment.Application.Contract.UOW;

namespace SnappFoodAssignment.InfraStructure.EFCore.Repositories.UOW;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly SnappFoodAssignmentDbContext _dbContext;

    public UnitOfWork(SnappFoodAssignmentDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<bool> SaveAsync()
    {
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public void Dispose()
    {
        _dbContext.Dispose();
        GC.SuppressFinalize(this);
    }
}
