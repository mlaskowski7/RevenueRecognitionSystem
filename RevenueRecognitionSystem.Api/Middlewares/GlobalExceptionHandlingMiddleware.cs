using System.Net;
using RevenueRecognitionSystem.Application.Dtos.Response;

namespace RevenueRecognitionSystem.Middlewares;

public class GlobalExceptionHandlingMiddleware(
    RequestDelegate next, 
    ILogger<GlobalExceptionHandlingMiddleware> logger)
{

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An unexpected exception occurred");
            var errResponse = new ErrorResponseDto(
                "INTERNAL SERVER ERROR", 
                HttpStatusCode.InternalServerError,
                "An unexpected exception occurred");
            await httpContext.Response.WriteAsJsonAsync(errResponse);
        }
    }
}