using SnappFoodAssignment.InfraStructure.EFCore.Extensions;

namespace SnappFoodAssignment.InfraStructure.EFCore.Repositories;
public class OrderRepository : Domain.Orders.IOrderRepository
{
    private readonly SnappFoodAssignmentDbContext _dbContext;

    public OrderRepository(SnappFoodAssignmentDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task AddAsync(Domain.Orders.Order order)
    {
        await _dbContext.Orders.AddAsync(order.ToOrderDataModel());
    }
}
