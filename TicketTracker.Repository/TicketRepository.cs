using TicketTracker.Repository.Data;
using TicketTracker.Repository.Interfaces;
using TicketTracker.Shared.Entities;

namespace TicketTracker.Repository;

public class TicketRepository : ITicketRepository
{
    private readonly TicketTrackerContext _context;

    public TicketRepository(TicketTrackerContext context)
    {
        _context = context;
    }

    public async Task<Ticket> CreateTicket(Ticket ticket)
    {
        await _context.Ticket.AddAsync(ticket);

        await _context.SaveChangesAsync();

        return ticket;
    }
}