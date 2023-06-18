using Microsoft.AspNetCore.Mvc;
using TicketTracker.Service.Interfaces;
using TicketTracker.Shared.Dtos;

namespace TicketTracker.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TicketController : ControllerBase
{
    private readonly ITicketService _service;

    public TicketController(ITicketService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTicket(TicketDto ticket)
    {
        var result = await _service.CreateTicket(ticket);

        return Ok(result);
    }
}