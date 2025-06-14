using RevenueRecognitionSystem.Application.Dtos.Request;
using RevenueRecognitionSystem.Application.Dtos.Response;
using RevenueRecognitionSystem.Domain.Models;

namespace RevenueRecognitionSystem.Application.Mappers.Impl;

public class ClientMapper : IClientMapper
{
    public IndividualClientResponseDto MapIndividualClientToResponse(IndividualClient client)
    {
        return new IndividualClientResponseDto(
            client.ClientId,
            client.Address,
            client.Email,
            client.PhoneNumber,
            client.FirstName,
            client.LastName,
            client.Pesel);
    }

    public CompanyClientResponseDto MapCompanyClientToResponse(CompanyClient client)
    {
        return new CompanyClientResponseDto(
            client.ClientId, 
            client.Address, 
            client.Email, 
            client.PhoneNumber, 
            client.Name, 
            client.KrsNumber);
    }

    public IndividualClient MapCreateRequestToIndividualClient(CreateIndividualClientRequestDto createIndividualClientRequestDto)
    {
        return new IndividualClient()
        {
            Address = createIndividualClientRequestDto.Address,
            FirstName = createIndividualClientRequestDto.FirstName,
            LastName = createIndividualClientRequestDto.LastName,
            Email = createIndividualClientRequestDto.Email,
            PhoneNumber = createIndividualClientRequestDto.PhoneNumber,
            Pesel = createIndividualClientRequestDto.Pesel,
        };
    }

    public CompanyClient MapCreateRequestToCompanyClient(CreateCompanyClientRequestDto companyClientRequestDto)
    {
        return new CompanyClient()
        {
            Address = companyClientRequestDto.Address,
            Email = companyClientRequestDto.Email,
            PhoneNumber = companyClientRequestDto.PhoneNumber,
            Name = companyClientRequestDto.Name,
            KrsNumber = companyClientRequestDto.KrsNumber,
        };
    }
}