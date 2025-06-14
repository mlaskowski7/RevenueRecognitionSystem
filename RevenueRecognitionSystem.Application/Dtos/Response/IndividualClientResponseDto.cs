namespace RevenueRecognitionSystem.Application.Dtos.Response;

public record IndividualClientResponseDto(
    Guid ClientId,
    string Address,
    string Email,
    string PhoneNumber,
    string FirstName,
    string LastName,
    string Pesel) : ClientResponseDto(ClientId, Address, Email, PhoneNumber);