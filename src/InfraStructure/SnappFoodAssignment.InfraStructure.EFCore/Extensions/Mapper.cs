using SnappFoodAssignment.InfraStructure.EFCore.DataModels;

namespace SnappFoodAssignment.InfraStructure.EFCore.Extensions;
public static class Mapper
{
    public static Domain.Products.Product ToProductDomain(this Product product)
    {
        return new Domain.Products.Product(product.Id, product.Title, 
            product.InventoryCount, product.Price, product.Discount);
    }

    public static Domain.Users.User ToUserDomain(this User user)
    {
        return new Domain.Users.User()
        {
            Id = user.Id,
            Name = user.Name,
        };
    }

    public static Domain.Orders.Order ToOrderDomain(this Order order)
    {
        return new Domain.Orders.Order()
        {
            Id = order.Id,
            ProductId = order.ProductId,
            UserId = order.UserId,
            OrderDate = order.OrderDate,
        };
    }

    public static Product ToProductDataModel(this Domain.Products.Product product)
    {
        return new Product()
        {
            Title = product.Title,
            Discount = product.Discount,
            InventoryCount = product.InventoryCount,
            Price = product.Price,
        };
    }

    public static Order ToOrderDataModel(this Domain.Orders.Order order)
    {
        return new Order()
        {
            ProductId = order.ProductId,
            UserId = order.UserId,
            OrderDate = order.OrderDate,
        };
    }
}
