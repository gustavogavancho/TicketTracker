using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TicketTracker.Service.Interfaces;
using TicketTracker.Shared.Dtos;
using TicketTracker.Shared.Pagination;

namespace TicketTracker.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TicketController : ControllerBase
{
    private readonly ITicketService _ticketService;
    private readonly IExcelService _excelService;

    public TicketController(ITicketService ticketService,
        IExcelService excelService)
    {
        _ticketService = ticketService;
        _excelService = excelService;
    }

    [HttpGet]
    public async Task<IActionResult> GetTicketsByPage([FromQuery] ItemsParameters itemsParameters)
    {
        var result = await _ticketService.GetAllTicketsByPage(itemsParameters);

        Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.MetaData));

        return Ok(result);
    }

    [HttpGet("exportTickets")]
    public async Task<IActionResult> ExportTicketsToExcel()
    {
        var result = await _excelService.GenerateExcelFile();

        return Ok(result);
    }

    [HttpGet("{id:int}", Name = "GetById")]
    public async Task<IActionResult> GetTicket(int id)
    {
        var result = await _ticketService.GetTicket(id);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTicket(TicketDto ticketDto)
    {
        var result = await _ticketService.CreateTicket(ticketDto);

        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateTicket(TicketDto ticketDto)
    {
        var result = await _ticketService.UpdateTicket(ticketDto);

        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteTicket(int id)
    {
        var result = await _ticketService.DeleteTicket(id);

        return Ok(result);
    }
}