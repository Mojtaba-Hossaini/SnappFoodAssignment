namespace SnappFoodAssignment.Application.Contract.Products.Dtos;
public class ProductDto
{
    public string Title { get; set; }
    public int InventoryCount { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
}
