namespace SnappFoodAssignment.Domain.Contract.Share;
public enum BusinessCodes
{
    Title40CharactersLimit = 4001,
    RequiredValueException = 4002,
    DuplicateProductException = 4003,
    NotFoundException = 4004,
    ZeroQuantityException = 4005,
    InventoryCountOutOfSaleException = 4006,
}
