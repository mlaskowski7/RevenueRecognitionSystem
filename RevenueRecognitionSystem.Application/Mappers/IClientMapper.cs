using RevenueRecognitionSystem.Application.Dtos.Request;
using RevenueRecognitionSystem.Application.Dtos.Response;
using RevenueRecognitionSystem.Domain.Models;

namespace RevenueRecognitionSystem.Application.Mappers;

public interface IClientMapper
{
    IndividualClientResponseDto MapIndividualClientToResponse(IndividualClient client);
    
    CompanyClientResponseDto MapCompanyClientToResponse(CompanyClient client);
    
    IndividualClient MapCreateRequestToIndividualClient(CreateIndividualClientRequestDto createIndividualClientRequestDto);
    
    CompanyClient MapCreateRequestToCompanyClient(CreateCompanyClientRequestDto companyClientRequestDto);
}