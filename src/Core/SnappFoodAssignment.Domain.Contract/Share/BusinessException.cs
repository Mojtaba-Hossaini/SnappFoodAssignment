namespace SnappFoodAssignment.Domain.Contract.Share;
public class BusinessException : Exception
{
    public virtual int Code { get; set; }
}
