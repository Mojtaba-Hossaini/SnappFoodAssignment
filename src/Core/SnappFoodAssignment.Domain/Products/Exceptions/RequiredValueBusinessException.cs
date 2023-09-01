using SnappFoodAssignment.Domain.Contract.Share;

namespace SnappFoodAssignment.Domain.Products.Exceptions;
public class RequiredValueBusinessException : BusinessException
{
    public RequiredValueBusinessException(string parameter)
    {
        Parameter = parameter;
    }
    public override string Message => string.Format(Messages.RequiredValueException, Parameter);
    public override int Code => (int)BusinessCodes.RequiredValueException;

    public string Parameter { get; }
}
