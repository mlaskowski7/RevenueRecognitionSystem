using System.ComponentModel.DataAnnotations;

namespace RevenueRecognitionSystem.Application.Dtos.Request;

public class UpdateIndividualClientRequestDto : UpdateClientRequestDto
{
    [Required]
    [MaxLength(30)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string LastName { get; set; } 
}