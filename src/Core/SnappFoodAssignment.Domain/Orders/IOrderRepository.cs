namespace SnappFoodAssignment.Domain.Orders;
public interface IOrderRepository
{
    Task AddAsync(Order order);
}