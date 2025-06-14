using RevenueRecognitionSystem.Application.Dtos.Request;
using RevenueRecognitionSystem.Application.Dtos.Response;
using RevenueRecognitionSystem.Application.Mappers;
using RevenueRecognitionSystem.Application.Repositories;
using RevenueRecognitionSystem.Application.Utils;
using RevenueRecognitionSystem.Domain.Models;

namespace RevenueRecognitionSystem.Application.Services.Impl;

public class ClientService(IClientRepository clientRepository, IClientMapper clientMapper) : IClientService
{
    public async Task<Result<ClientResponseDto>> CreateClientAsync(CreateClientRequestDto createClientRequestDto, CancellationToken cancellationToken = default)
    {
        switch (createClientRequestDto)
        {
            case CreateIndividualClientRequestDto createIndividualClientRequestDto:
                var client = clientMapper.MapCreateRequestToIndividualClient(createIndividualClientRequestDto);
                
                var (savedIndividualClient, err) = await clientRepository.CreateIndividualClientAsync(client, cancellationToken);
                if (err is null && savedIndividualClient is not null)
                {
                    var response = clientMapper.MapIndividualClientToResponse(savedIndividualClient);
                    return Result<ClientResponseDto>.Ok(response);
                }
                
                return Result<ClientResponseDto>.Err(err!);
            case CreateCompanyClientRequestDto createCompanyClientRequestDto:
                var companyClient = clientMapper.MapCreateRequestToCompanyClient(createCompanyClientRequestDto);
                var (savedCompanyClient, createErr) = await clientRepository.CreateCompanyClientAsync(companyClient, cancellationToken);
                if (createErr is null && savedCompanyClient is not null)
                {
                    var response = clientMapper.MapCompanyClientToResponse(savedCompanyClient);
                    return Result<ClientResponseDto>.Ok(response);
                }
            
                return Result<ClientResponseDto>.Err(createErr!);
            default:
                throw new InvalidOperationException();
        } 
    }

    public async Task<Error?> DeleteClientAsync(Guid clientId, CancellationToken cancellationToken = default)
    {
        var (client, err) = await clientRepository.GetClientByIdAsync(clientId, cancellationToken);
        if (err is not null)
        {
            return err;
        }

        if (client is null)
        {
            return Error.NotFound($"Client with id {clientId} was not found");
        }

        if (client is CompanyClient cc)
        {
            return Error.BadRequest($"Cannot delete a company client (KRS number: {cc.KrsNumber})");
        }
        
        var deleteErr = await clientRepository.SoftDeleteIndividualClientAsync((IndividualClient)client, cancellationToken);
        return deleteErr;
    }

    public async Task<Result<ClientResponseDto>> UpdateClientByIdAsync(Guid clientId, UpdateClientRequestDto updateClientRequestDto,
        CancellationToken cancellationToken = default)
    {
        var (client, err) = await clientRepository.GetClientByIdAsync(clientId, cancellationToken);
        if (err is not null)
        {
            return Result<ClientResponseDto>.Err(err);
        }

        if (client is null)
        {
            return Result<ClientResponseDto>.Err(Error.NotFound($"Client with id {clientId} was not found"));
        }

        switch (client!, updateClientRequestDto)
        {
            case (CompanyClient, UpdateIndividualClientRequestDto):
                return Result<ClientResponseDto>.Err(Error.BadRequest($"Client with id {clientId} is a company, cannot update with fields for individual clients"));
            case (IndividualClient, UpdateCompanyClientRequestDto):
                return Result<ClientResponseDto>.Err(Error.BadRequest($"Client with id {client} is an individual client, cannot update with fields for company clients"));
            case (CompanyClient cc, UpdateCompanyClientRequestDto cr):
                return await UpdateCompanyClientAsync(cc, cr, cancellationToken);
            case (IndividualClient ic, UpdateIndividualClientRequestDto ir):
                return await UpdateIndividualClientAsync(ic, ir, cancellationToken);
            default:
                throw new InvalidOperationException();
        }
    }

    private async Task<Result<ClientResponseDto>> UpdateCompanyClientAsync(
        CompanyClient client,
        UpdateCompanyClientRequestDto updateCompanyClientRequestDto,
        CancellationToken cancellationToken = default)
    {
        client.PhoneNumber = updateCompanyClientRequestDto.PhoneNumber;
        client.Email = updateCompanyClientRequestDto.Email;
        client.Address = updateCompanyClientRequestDto.Address;
        client.Name = updateCompanyClientRequestDto.Name;
                
        var (updatedCompanyClient, updateCompanyErr) = await clientRepository.UpdateCompanyClient(client, cancellationToken);
        if (updateCompanyErr is not null)
        {
            return Result<ClientResponseDto>.Err(updateCompanyErr);
        }

        var response = clientMapper.MapCompanyClientToResponse(updatedCompanyClient!);
        return Result<ClientResponseDto>.Ok(response); 
    }

    private async Task<Result<ClientResponseDto>> UpdateIndividualClientAsync(
        IndividualClient client,
        UpdateIndividualClientRequestDto updateIndividualClientRequestDto,
        CancellationToken cancellationToken = default)
    {
        client.PhoneNumber = updateIndividualClientRequestDto.PhoneNumber;
        client.Email = updateIndividualClientRequestDto.Email;
        client.Address = updateIndividualClientRequestDto.Address;
        client.FirstName = updateIndividualClientRequestDto.FirstName;
        client.LastName = updateIndividualClientRequestDto.LastName;
                
        var (updatedIndividualClient, updateIndividualErr) = await clientRepository.UpdateIndividualClient(client, cancellationToken);
        if (updateIndividualErr is not null)
        {
            return Result<ClientResponseDto>.Err(updateIndividualErr);
        }

        var clientResp = clientMapper.MapIndividualClientToResponse(updatedIndividualClient!);
        return Result<ClientResponseDto>.Ok(clientResp); 
    }
}