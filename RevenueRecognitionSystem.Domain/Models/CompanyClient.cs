namespace RevenueRecognitionSystem.Domain.Models;

public class CompanyClient : Client
{
    public required string Name { get; set; }
    
    public required string KrsNumber { get; set; }
}