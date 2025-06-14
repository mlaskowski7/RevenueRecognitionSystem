namespace RevenueRecognitionSystem.Application.Dtos.Response;

public record CompanyClientResponseDto(
    Guid ClientId,
    string Address,
    string Email,
    string PhoneNumber,
    string Name,
    string KrsNumber) : ClientResponseDto(ClientId, Address, Email, PhoneNumber);