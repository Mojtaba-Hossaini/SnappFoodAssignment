using SnappFoodAssignment.Application.Contract.Products.Dtos;
using SnappFoodAssignment.Domain.Products;

namespace SnappFoodAssignment.Application.Extensions;
public static class Mapper
{
    public static ProductDto ToProductDto(this Product product) => new ProductDto
    {
        InventoryCount = product.InventoryCount,
        Price = product.Price - product.Discount,
        Title = product.Title,
        Discount = product.Discount,
    };

    public static Product ToCoreDomain(this ProductDto product) => new Product(0, product.Title,
        product.InventoryCount, product.Price, product.Discount);
}
