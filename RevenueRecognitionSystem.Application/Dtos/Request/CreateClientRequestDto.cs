using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RevenueRecognitionSystem.Application.Dtos.Request;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "clientType")]
[JsonDerivedType(typeof(CreateIndividualClientRequestDto), typeDiscriminator: "individual")]
[JsonDerivedType(typeof(CreateCompanyClientRequestDto), typeDiscriminator: "company")]
public abstract class CreateClientRequestDto
{
    [Required]
    [MaxLength(100)]
    public string Address { get; set; }
    
    [Required]
    [EmailAddress]
    [MaxLength(50)]
    public string Email { get; set; }
    
    [Required]
    [MaxLength(30)]
    [Phone]
    public string PhoneNumber { get; set; }
}