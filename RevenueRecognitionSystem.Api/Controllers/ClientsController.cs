using Microsoft.AspNetCore.Mvc;
using RevenueRecognitionSystem.Application.Dtos.Request;
using RevenueRecognitionSystem.Application.Dtos.Response;
using RevenueRecognitionSystem.Application.Services;
using RevenueRecognitionSystem.Extensions;

namespace RevenueRecognitionSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientsController(IClientService clientService) : ControllerBase
{

    [HttpPost]
    [ProducesResponseType(typeof(ClientResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddClient([FromBody] CreateClientRequestDto createClientRequestDto, CancellationToken cancellationToken = default)
    {
        var clientRes = await clientService.CreateClientAsync(createClientRequestDto, cancellationToken);
        return this.OkFromResult<ClientResponseDto>(clientRes);
    }

    [HttpDelete("{clientId:guid}")]
    [ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> RemoveClient([FromRoute] Guid clientId,
        CancellationToken cancellationToken = default)
    {
        var err = await clientService.DeleteClientAsync(clientId, cancellationToken);
        if (err is not null)
        {
            return this.Err(err);
        }
        
        return NoContent();
    }

    [HttpPut("{clientId:guid}")]
    [ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateClient(
        [FromRoute] Guid clientId,
        [FromBody] UpdateClientRequestDto updateClientRequestDto,
        CancellationToken cancellationToken = default)
    {
        var updateRes = await clientService.UpdateClientByIdAsync(clientId, updateClientRequestDto, cancellationToken);
        return this.OkFromResult<ClientResponseDto>(updateRes);
    }
    
}