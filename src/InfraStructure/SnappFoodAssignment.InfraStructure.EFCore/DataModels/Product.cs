namespace SnappFoodAssignment.InfraStructure.EFCore.DataModels;
public class Product
{
    public long Id { get; set; }

    public string Title { get; set; }

    public int InventoryCount { get; set; }

    public decimal Price { get; set; }

    public decimal Discount { get; set; }
}
