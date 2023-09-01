namespace SnappFoodAssignment.InfraStructure.EFCore.DataModels;
public class Order
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public long ProductId { get; set; }

    public virtual User User { get; set; }

    public virtual Product Product { get; set; }

    public DateTimeOffset OrderDate { get; set; }
}
