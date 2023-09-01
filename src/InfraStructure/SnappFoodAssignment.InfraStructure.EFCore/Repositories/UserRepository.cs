using Microsoft.EntityFrameworkCore;
using SnappFoodAssignment.Domain.Users.Exceptions;
using SnappFoodAssignment.InfraStructure.EFCore.Extensions;

namespace SnappFoodAssignment.InfraStructure.EFCore.Repositories;
public class UserRepository : Domain.Users.IUserRepository
{
    private readonly SnappFoodAssignmentDbContext _dbContext;

    public UserRepository(SnappFoodAssignmentDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Domain.Users.User> GetByIdAsync(long userId)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(c => c.Id == userId);
        if (user == null) throw new UserNotFoundBusinessException();
        return user.ToUserDomain();
    }
}
