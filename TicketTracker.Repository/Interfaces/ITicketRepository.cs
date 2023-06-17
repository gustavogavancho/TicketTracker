using TicketTracker.Shared.Entities;

namespace TicketTracker.Repository.Interfaces;

public interface ITicketRepository
{
    Task<Ticket> CreateTicket(Ticket ticket);
}