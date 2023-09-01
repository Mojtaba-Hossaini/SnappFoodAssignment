using SnappFoodAssignment.Domain.Contract.Share;

namespace SnappFoodAssignment.Domain.Products.Exceptions;
public class Title40CharactersLimitException : BusinessException
{
    public override string Message => Messages.Title40CharactersLimit;
    public override int Code => (int)BusinessCodes.Title40CharactersLimit;
}
