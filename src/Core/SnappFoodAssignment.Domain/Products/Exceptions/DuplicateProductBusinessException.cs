using SnappFoodAssignment.Domain.Contract.Share;

namespace SnappFoodAssignment.Domain.Products.Exceptions;
public class DuplicateProductBusinessException : BusinessException
{
    public override string Message => Messages.DuplicateProductException;
    public override int Code => (int)BusinessCodes.DuplicateProductException;
}