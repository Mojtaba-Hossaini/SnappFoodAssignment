namespace SnappFoodAssignment.Domain.Users;
public interface IUserRepository
{
    Task<User> GetByIdAsync(long userId);
}