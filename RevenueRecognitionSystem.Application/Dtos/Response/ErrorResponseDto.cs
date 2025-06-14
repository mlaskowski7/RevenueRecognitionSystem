using System.Net;

namespace RevenueRecognitionSystem.Application.Dtos.Response;

public record ErrorResponseDto(
    string Title,
    HttpStatusCode Status,
    string? Message);