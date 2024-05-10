using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/client")]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet("{clientId}")]
    public IActionResult GetClient(int clientId)
    {
        var client = _clientService.GetClientDetails(clientId);
        if (client == null)
        {
            return NotFound();
        }
        return Ok(client);
    }

    [HttpDelete("{clientId}")]
    public IActionResult DeleteClient(int clientId)
    {
        _clientService.DeleteClient(clientId);
        return NoContent();
    }
}