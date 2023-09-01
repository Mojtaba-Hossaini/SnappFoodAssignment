using SnappFoodAssignment.Api.Dtos;
using SnappFoodAssignment.Domain.Contract.Share;
using System.Net;

namespace SnappFoodAssignment.Api.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        this.next = next;
    }
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch (BusinessException ex)
        {

            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, BusinessException exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        var response = new ErrorResponseDto
        {
            Code = exception.Code,
            ErrorMessage = exception.Message,
        };
        await context.Response.WriteAsJsonAsync(response);
    }
}
