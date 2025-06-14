using System.ComponentModel.DataAnnotations;

namespace RevenueRecognitionSystem.Application.Dtos.Request;

public class UpdateCompanyClientRequestDto : UpdateClientRequestDto
{
    [Required]
    [MaxLength(30)]
    public string Name { get; set; }
}