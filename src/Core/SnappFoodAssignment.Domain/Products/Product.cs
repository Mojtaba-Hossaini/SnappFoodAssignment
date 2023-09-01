using SnappFoodAssignment.Domain.Products.Exceptions;

namespace SnappFoodAssignment.Domain.Products;
public class Product
{
    public Product(long id, string title, int inventoryCount, decimal price, decimal discount)
    {
        Id = id;
        Title = title;
        InventoryCount = inventoryCount;
        Price = price;
        Discount = discount;
        GuardAgainstNotValidInput();
    }

    public long Id { get; set; }

    public string Title { get; set; }

    public int InventoryCount { get; set; }

    public decimal Price { get; set; }

    public decimal Discount { get; set; }

    private void GuardAgainstNotValidInput()
    {
        if (string.IsNullOrEmpty(Title))
            throw new RequiredValueBusinessException(nameof(Title));
        if (Title.Length > 40)
            throw new Title40CharactersLimitException();
    }

    public void UpdateInventoryCount(int quantity)
    {
        InventoryCount += quantity;
    }
}
