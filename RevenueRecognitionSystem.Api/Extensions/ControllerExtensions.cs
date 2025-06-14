using System.Net;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RevenueRecognitionSystem.Application.Dtos.Response;
using RevenueRecognitionSystem.Application.Utils;

namespace RevenueRecognitionSystem.Extensions;

public static class ControllerExtensions
{
    public static IActionResult Err(this ControllerBase controller, Error error)
    {
        return error.Type switch
        {
            ErrorType.Error =>
                controller.StatusCode(500,
                    new ErrorResponseDto("INTERNAL SERVER ERROR", HttpStatusCode.InternalServerError, error.Message)),
            ErrorType.NotFound =>
                controller.NotFound(new ErrorResponseDto("NOT FOUND", HttpStatusCode.NotFound, error.Message)),
            ErrorType.Conflict =>
                controller.Conflict(new ErrorResponseDto("CONFLICT", HttpStatusCode.Conflict, error.Message)),
            ErrorType.BadRequest =>
                controller.BadRequest(new ErrorResponseDto("BAD REQUEST", HttpStatusCode.BadRequest, error.Message)),
            _ => throw new InvalidOperationException()
        };
    }

    public static IActionResult OkFromResult<T>(this ControllerBase controller, Result<T> result)
    {
        return result switch
        {
            { IsErr: false } => controller.Ok(result.Value),
            _ => controller.Err(result.Error)
        };
    }
}