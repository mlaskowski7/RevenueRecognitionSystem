namespace RevenueRecognitionSystem.Domain.Models;

public class CompanyClient : Client
{
    public required string Name { get; set; }
    
    public required int KrsNumber { get; set; }
}