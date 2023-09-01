using Microsoft.Extensions.DependencyInjection;
using SnappFoodAssignment.Application.ApplicationServices.Products;
using SnappFoodAssignment.Application.Contract.Products;

namespace SnappFoodAssignment.Application.Extensions;
public static class ServiceCollectionExtension
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
    }
}
