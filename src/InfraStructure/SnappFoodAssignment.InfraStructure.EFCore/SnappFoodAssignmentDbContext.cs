using Microsoft.EntityFrameworkCore;
using SnappFoodAssignment.InfraStructure.EFCore.DataModels;

namespace SnappFoodAssignment.InfraStructure.EFCore;
public class SnappFoodAssignmentDbContext : DbContext
{
    public SnappFoodAssignmentDbContext(DbContextOptions<SnappFoodAssignmentDbContext> options) : base(options)
    {
        
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
}
