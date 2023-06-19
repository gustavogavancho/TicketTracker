﻿using Microsoft.AspNetCore.Mvc;
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
}