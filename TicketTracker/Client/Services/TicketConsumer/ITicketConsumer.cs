using TicketTracker.Shared.Dtos;

namespace TicketTracker.Client.Services.TicketConsumer;

public interface ITicketConsumer
{
    Task<TicketDto> CreateTicket(TicketDto ticket);
}