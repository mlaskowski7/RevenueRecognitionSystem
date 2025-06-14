using Microsoft.EntityFrameworkCore;
using RevenueRecognitionSystem.Application.Repositories;
using RevenueRecognitionSystem.Application.Utils;
using RevenueRecognitionSystem.Domain.Models;
using RevenueRecognitionSystem.Infrastructure.Database;
using RevenueRecognitionSystem.Infrastructure.Utils;

namespace RevenueRecognitionSystem.Infrastructure.Repositories;

public class ClientRepository(
    RevenuesDbContext dbContext,
    IDateTimeProvider dateTimeProvider) : IClientRepository
{
    public async Task<(IndividualClient?, Error?)> CreateIndividualClientAsync(IndividualClient client, CancellationToken cancellationToken = default)
    {
        return await DbOperationsUtils.TryAsync<IndividualClient>(async () =>
        {
            var saved = await dbContext.IndividualClients.AddAsync(client, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
            return saved.Entity;
        });
    }

    public async Task<(CompanyClient?, Error?)> CreateCompanyClientAsync(CompanyClient client, CancellationToken cancellationToken = default)
    {
        return await DbOperationsUtils.TryAsync<CompanyClient>(async () =>
        {
            var saved = await dbContext.CompanyClients.AddAsync(client, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
            return saved.Entity;
        });
    }

    public async Task<Error?> SoftDeleteIndividualClientAsync(IndividualClient client, CancellationToken cancellationToken = default)
    {
        return await DbOperationsUtils.TryAsync(async () =>
        {
            client.IsDeleted = true;
            client.DeletedAt = dateTimeProvider.Now;
            dbContext.IndividualClients.Update(client);
            await dbContext.SaveChangesAsync(cancellationToken);
        });
    }

    public async Task<(Client?, Error?)> GetClientByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await DbOperationsUtils.TryAsync<Client>(async () =>
        {
            var client = await dbContext.Clients.FirstOrDefaultAsync(c => c.ClientId == id, cancellationToken);
            return client is IndividualClient { IsDeleted: true } ? 
                null : 
                client;
        });
    }

    public async Task<(IndividualClient?, Error?)> UpdateIndividualClient(IndividualClient client, CancellationToken cancellationToken = default)
    {
        return await DbOperationsUtils.TryAsync<IndividualClient>(async () =>
        {
            var updated = dbContext.IndividualClients.Update(client);
            await dbContext.SaveChangesAsync(cancellationToken);
            return updated.Entity;
        });
    }

    public async Task<(CompanyClient?, Error?)> UpdateCompanyClient(CompanyClient client, CancellationToken cancellationToken = default)
    {
        return await DbOperationsUtils.TryAsync<CompanyClient>(async () =>
        {
            var updated = dbContext.CompanyClients.Update(client);
            await dbContext.SaveChangesAsync(cancellationToken);
            return updated.Entity;
        });
    }
}