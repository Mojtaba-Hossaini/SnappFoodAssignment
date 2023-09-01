using SnappFoodAssignment.Domain.Contract.Share;

namespace SnappFoodAssignment.Domain.Users.Exceptions;
public class UserNotFoundBusinessException : BusinessException
{
    public override string Message => Messages.NotFoundException;
    public override int Code => (int)BusinessCodes.NotFoundException;
}