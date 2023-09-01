namespace SnappFoodAssignment.Application.Contract.UOW;
public interface IUnitOfWork
{
    Task<bool> SaveAsync();
}