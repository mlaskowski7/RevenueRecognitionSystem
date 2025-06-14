using RevenueRecognitionSystem.Application.Dtos.Request;
using RevenueRecognitionSystem.Application.Dtos.Response;
using RevenueRecognitionSystem.Application.Utils;

namespace RevenueRecognitionSystem.Application.Services;

public interface IClientService
{
    Task<Result<ClientResponseDto>> CreateClientAsync(CreateClientRequestDto createClientRequestDto, CancellationToken cancellationToken = default);
    
    Task<Error?> DeleteClientAsync(Guid clientId, CancellationToken cancellationToken = default);
    
    Task<Result<ClientResponseDto>> UpdateClientByIdAsync(Guid clientId, UpdateClientRequestDto updateClientRequestDto, CancellationToken cancellationToken = default);
}