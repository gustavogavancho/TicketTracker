using TicketTracker.Shared.Dtos;

namespace TicketTracker.Client.Services.TicketConsumer;

public interface ITicketConsumer
{
    Task<TicketDto> CreateTicket(TicketDto ticket);
    Task<List<TicketDto>> GetAllTickets();
    Task<TicketDto> GetTicket(int ticketId);
    Task<TicketDto> UpdateTicket(TicketDto ticket);
}