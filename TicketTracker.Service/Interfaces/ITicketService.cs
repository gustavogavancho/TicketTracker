using TicketTracker.Shared.Dtos;

namespace TicketTracker.Service.Interfaces;

public interface ITicketService
{
    Task<TicketDto> CreateTicket(TicketDto ticketDto);
    Task<TicketDto> GetTicket(int ticketId);
    Task<TicketDto> UpdateTicket(TicketDto ticketDto);
}