namespace SnappFoodAssignment.Domain.Orders;
public class Order
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long ProductId { get; set; }
    public DateTimeOffset OrderDate { get; set; }
}
