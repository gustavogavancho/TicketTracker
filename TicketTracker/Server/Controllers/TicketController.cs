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

    [HttpGet]
    public async Task<IActionResult> GetTickets()
    {
        var result = await _service.GetAllTickets();

        return Ok(result);
    }

    [HttpGet("{id:int}", Name = "GetById")]
    public async Task<IActionResult> GetTicket(int id)
    {
        var result = await _service.GetTicket(id);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTicket(TicketDto ticketDto)
    {
        var result = await _service.CreateTicket(ticketDto);

        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateTicket(TicketDto ticketDto)
    {
        var result = await _service.UpdateTicket(ticketDto);

        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteTicket(int id)
    {
        var result = await _service.DeleteTicket(id);

        return Ok(result);
    }
}