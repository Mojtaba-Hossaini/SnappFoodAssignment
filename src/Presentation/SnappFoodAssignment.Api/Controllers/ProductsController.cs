using Microsoft.AspNetCore.Mvc;
using SnappFoodAssignment.Application.Contract.Products;
using SnappFoodAssignment.Application.Contract.Products.Dtos;

namespace SnappFoodAssignment.Api.Controllers;

public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        this._productService = productService;
    }

    [HttpGet("{id}")]
    public async Task<ProductDto> GetProduct(long id)
    {
        return await _productService.GetProductAsync(id);
    }

    [HttpPost("AddProduct")]
    public async Task<IActionResult> AddProduct([FromBody] ProductDto productDto)
    {
        await _productService.AddProductAsync(productDto);
        return Ok();
    }

    [HttpPatch("IncreaseInventoryCount")]
    public async Task<IActionResult> UpdateInventoryCount([FromBody] ProductInventoryUpdateRequestDto request)
    {
        await _productService.UpdateInventoryCountAsync(request.ProductId, request.Quantity);
        return Ok();
    }

    [HttpPost("OrderProduct")]
    public async Task<IActionResult> OrderProduct([FromBody] BuyProductRequestDto request)
    {
        var result = await _productService.OrderProductAsync(request.ProductId, request.UserId, request.Quantity);
        if(result)
            return Ok();
        return BadRequest();

    }
}
