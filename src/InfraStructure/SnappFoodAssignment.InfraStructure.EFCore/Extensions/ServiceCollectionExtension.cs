using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SnappFoodAssignment.Application.Contract.UOW;
using SnappFoodAssignment.Domain.Orders;
using SnappFoodAssignment.Domain.Products;
using SnappFoodAssignment.Domain.Users;
using SnappFoodAssignment.InfraStructure.EFCore.Repositories;
using SnappFoodAssignment.InfraStructure.EFCore.Repositories.UOW;

namespace SnappFoodAssignment.InfraStructure.EFCore.Extensions;
public static class ServiceCollectionExtension
{
    public static void AddInfrastructureServices(this IServiceCollection services, string? connectionString)
    {
        services.AddDbContext<SnappFoodAssignmentDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
