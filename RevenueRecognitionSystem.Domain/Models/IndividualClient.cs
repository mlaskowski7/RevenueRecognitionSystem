namespace RevenueRecognitionSystem.Domain.Models;

public class IndividualClient : Client
{
    public required string FirstName { get; set; }
    
    public required string LastName { get; set; }
    
    public required string Pesel { get; set; }
}