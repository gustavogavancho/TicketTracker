using Microsoft.EntityFrameworkCore;
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

    public async Task<List<Ticket>> GetAllTickets()
    {
        var tickets = await _context.Ticket.ToListAsync();

        return tickets;
    }

    public async Task<Ticket> GetTicket(int ticketId, bool trackChanged)
    {
        var ticket = trackChanged ? await _context.Ticket.FirstOrDefaultAsync(x => x.Id == ticketId)
            : await _context.Ticket.AsNoTracking().FirstOrDefaultAsync(x => x.Id == ticketId);

        return ticket;
    }

    public async Task<Ticket> UpdateTicket(Ticket ticket)
    {
        var result = _context.Ticket.Update(ticket);

        await _context.SaveChangesAsync();

        return result.Entity;
    }
}