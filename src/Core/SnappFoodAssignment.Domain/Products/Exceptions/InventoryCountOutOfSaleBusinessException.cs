using SnappFoodAssignment.Domain.Contract.Share;

namespace SnappFoodAssignment.Domain.Products.Exceptions;
public class InventoryCountOutOfSaleBusinessException : BusinessException
{
    public override string Message => Messages.InventoryCountOutOfSaleException;
    public override int Code => (int)BusinessCodes.DuplicateProductException;
}