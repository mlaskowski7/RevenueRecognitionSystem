using System.ComponentModel.DataAnnotations;

namespace RevenueRecognitionSystem.Application.Dtos.Request;

public class CreateCompanyClientRequestDto : CreateClientRequestDto
{
    [Required]
    [MaxLength(30)]
    public string Name { get; set; }
    
    [Required]
    [StringLength(10, MinimumLength = 10)]
    public string KrsNumber { get; set; }
}