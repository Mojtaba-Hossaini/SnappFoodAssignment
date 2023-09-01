using SnappFoodAssignment.Domain.Products;

namespace SnappFoodAssignment.Test.Helper;
public class TestProductList
{
    public static List<Product> GetTestProductList()
    {
        return new List<Product>()
            {
                new Product(1, "Book 1", 1, 1000, 10),
                new Product(2, "Book 2", 2, 2000, 20)
            };
    }
}
