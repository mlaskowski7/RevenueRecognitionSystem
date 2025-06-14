using System.Net;
using Microsoft.AspNetCore.Mvc;
using RevenueRecognitionSystem.Application.Dtos.Response;

namespace RevenueRecognitionSystem.Extensions;

public static class ConfigurationExtensions
{
    public static IServiceCollection AddConfiguration(this IServiceCollection services)
    {
        return services.Configure<ApiBehaviorOptions>(opt =>
        {
            opt.InvalidModelStateResponseFactory = context =>
            {
                var errors = context.ModelState
                    .Where(x => x.Value?.Errors.Count > 0)
                    .SelectMany(kvp => kvp.Value!.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                var response = new ErrorResponseDto(
                    Title: "BAD REQUEST",
                    Status: HttpStatusCode.BadRequest,
                    Message: string.Join(" | ", errors)
                );

                return new BadRequestObjectResult(response);
            };
        });
    } 
}