using TicketTracker.Shared.Dtos;

namespace TicketTracker.Service.Interfaces;

public interface ITicketService
{
    Task<TicketDto> CreateTicket(TicketDto ticketDto);
}