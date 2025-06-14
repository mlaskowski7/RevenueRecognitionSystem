using System.ComponentModel.DataAnnotations;

namespace RevenueRecognitionSystem.Application.Dtos.Request;

public class CreateIndividualClientRequestDto : CreateClientRequestDto
{
    [Required]
    [MaxLength(30)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }
    
    [Required]
    [StringLength(11, MinimumLength = 11)]
    public string Pesel { get; set; }
}