namespace RevenueRecognitionSystem.Application.Dtos.Response;

public abstract record ClientResponseDto(
    Guid ClientId,
    string Address,
    string Email,
    string PhoneNumber);