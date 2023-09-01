using SnappFoodAssignment.Domain.Contract.Share;

namespace SnappFoodAssignment.Domain.GeneralExceptions;
public class NotFoundBusinessException : BusinessException
{
    public override string Message => Messages.NotFoundException;
    public override int Code => (int)BusinessCodes.NotFoundException;
}