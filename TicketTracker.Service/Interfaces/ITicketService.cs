using Microsoft.AspNetCore.Http;
using TicketTracker.Shared.Dtos;

namespace TicketTracker.Service.Interfaces;

public interface ITicketService
{
    Task<TicketDto> CreateTicket(TicketDto ticketDto);
    Task<TicketDto> GetTicket(int ticketId, bool trackChanges);
    Task<TicketDto> UpdateTicket(int ticketId, TicketDto ticketDto);
}