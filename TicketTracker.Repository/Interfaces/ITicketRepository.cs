using TicketTracker.Shared.Entities;

namespace TicketTracker.Repository.Interfaces;

public interface ITicketRepository
{
    Task<Ticket> CreateTicket(Ticket ticket);
    Task<Ticket> GetTicket(int ticketId, bool trackChanged);
    Task<Ticket> UpdateTicket(Ticket ticket);
}