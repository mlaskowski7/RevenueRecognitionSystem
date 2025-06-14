namespace RevenueRecognitionSystem.Domain.Models;

public class IndividualClient : Client, ISoftDelete
{
    public required string FirstName { get; set; }
    
    public required string LastName { get; set; }
    
    public required string Pesel { get; set; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
}