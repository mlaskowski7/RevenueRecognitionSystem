using RevenueRecognitionSystem.Application.Utils;
using RevenueRecognitionSystem.Domain.Models;

namespace RevenueRecognitionSystem.Application.Repositories;

public interface IClientRepository
{
    Task<(IndividualClient?, Error?)> CreateIndividualClientAsync(IndividualClient client, CancellationToken cancellationToken = default);
    
    Task<(CompanyClient?, Error?)> CreateCompanyClientAsync(CompanyClient client, CancellationToken cancellationToken = default);
    
    Task<Error?> SoftDeleteIndividualClientAsync(IndividualClient client, CancellationToken cancellationToken = default);
    
    Task<(Client?, Error?)> GetClientByIdAsync(Guid id, CancellationToken cancellationToken = default);
    
    Task<(IndividualClient?, Error?)> UpdateIndividualClient(IndividualClient client, CancellationToken cancellationToken = default);
    
    Task<(CompanyClient?, Error?)> UpdateCompanyClient(CompanyClient client, CancellationToken cancellationToken = default);
}