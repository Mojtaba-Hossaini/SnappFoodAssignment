namespace SnappFoodAssignment.Application.Contract.Products.Dtos;
public class BuyProductRequestDto
{
    public long ProductId { get; set; }
    public long UserId { get; set; }
    public int Quantity { get; set; }
}