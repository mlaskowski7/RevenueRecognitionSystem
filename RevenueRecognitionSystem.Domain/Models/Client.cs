namespace RevenueRecognitionSystem.Domain.Models;

public abstract class Client
{
    public Guid ClientId { get; set; }
    
    public required string Address { get; set; }
    
    public required string Email { get; set; }
    
    public required string PhoneNumber { get; set; }
    
    public bool IsDeleted { get; set; }
}