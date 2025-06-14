namespace RevenueRecognitionSystem.Domain.Models;

public class Discount
{
    public Guid DiscountId { get; set; }
    
    public required string Name { get; set; }
    
    public required string Description { get; set; }
    
    public required int Percentage { get; set; }
    
    public required DateTime StartDate { get; set; }
    
    public required DateTime EndDate { get; set; }
}