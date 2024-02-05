using TicketTracker.Shared.Entities;

namespace TicketTracker.Repository.Interfaces;

public interface ITicketRepository
{
    Task<Ticket> CreateTicket(Ticket ticket);
    Task<Ticket> GetTicket(int ticketId);
    Task<Ticket> UpdateTicket(Ticket ticket);
    Task<decimal?> GetTotalAmount(int year);
    Task<decimal?> GetTotalAmoutByType(string ticketType, int year);
    Task<List<Ticket>> GetAllTickets(int year);
    Task<IEnumerable<Ticket>> GetAllTicketsByPage(int pageNumber, int pageSize, int year);
    Task<int> CountAllTickets(int year);
    Task<bool> DeleteTicket(int ticketId);
}