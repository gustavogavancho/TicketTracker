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

    [HttpGet("{id:int}", Name = "GetById")]
    public async Task<IActionResult> GetTicket(int id)
    {
        var result = await _service.GetTicket(id, false);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTicket(TicketDto ticketDto)
    {
        var result = await _service.CreateTicket(ticketDto);

        return Ok(result);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateTicket(int ticketId, TicketDto ticketDto)
    {
        await _service.UpdateTicket(ticketId, ticketDto);

        return NoContent();
    }

    [HttpPost("{ticketId:int}/image")]
    public async Task<IActionResult> UploadImage(int ticketId)
    {
        var ticket = await _service.GetTicket(ticketId, false);
        if (ticket is null)
            return BadRequest("Ticket does not exist.");

        var file = Request.Form.Files[0];
        if (file.Length == 0)
            return BadRequest("No image found.");

        var filename = $"{Guid.NewGuid()}.jpg";
        var saveLocation = Path.Combine(Directory.GetCurrentDirectory(), "Images", filename);

        var resizeOptions = new ResizeOptions
        {
            Mode = ResizeMode.Pad,
            Size = new Size(640, 426)
        };

        using var image = Image.Load(file.OpenReadStream());
        image.Mutate(x => x.Resize(resizeOptions));
        await image.SaveAsJpegAsync(saveLocation);

        if (!string.IsNullOrWhiteSpace(ticket.Image))
        {
            System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "Images", ticket.Image));
        }

        ticket.Image = filename;

        await _service.UpdateTicket(ticketId, ticket);

        return Ok(ticket.Image);
    }
}