namespace RevenueRecognitionSystem.Domain.Models;

public class SoftwareSystem
{
    public Guid SoftwareSystemId { get; set; }
    
    public required string Name { get; set; }
    
    public required string Description { get; set; }
    
    public required string Version { get; set; }
    
    public required string Category { get; set; }
    
    public required bool IsSoldUpfront { get; set; }
    
    public required bool IsSoldAsSubscription { get; set; }
    
    public required decimal PricePerYear { get; set; }
}