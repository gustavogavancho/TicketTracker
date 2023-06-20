using TicketTracker.Shared.Entities;

namespace TicketTracker.Repository.Interfaces;

public interface ITicketRepository
{
    Task<Ticket> CreateTicket(Ticket ticket);
    Task<Ticket> GetTicket(int ticketId);
    Task<Ticket> UpdateTicket(Ticket ticket);
    Task<List<Ticket>> GetAllTickets();
}