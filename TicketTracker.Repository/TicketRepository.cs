using Microsoft.EntityFrameworkCore;
using TicketTracker.Repository.Data;
using TicketTracker.Repository.Interfaces;
using TicketTracker.Shared.Entities;

namespace TicketTracker.Repository;

public class TicketRepository : ITicketRepository, IDisposable
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

    public async Task<bool> DeleteTicket(int ticketId)
    {
        var ticket = await _context.Ticket.FirstOrDefaultAsync(x => x.Id == ticketId);

        _context.Ticket.Remove(ticket);

        var result = await _context.SaveChangesAsync() == 1;

        return result;
    }

    public async Task<List<Ticket>> GetAllTickets(int year)
    {
        var tickets = await _context.Ticket.Where(x=> x.DateIssued.Value.Date.Year == year).AsNoTracking().OrderByDescending(x => x.DateIssued).ToListAsync();

        return tickets;
    }


    public async Task<IEnumerable<Ticket>> GetAllTicketsByPage(int pageNumber, int pageSize, int year)
    {
        var tickets = await _context.Ticket.AsNoTracking().OrderByDescending(x => x.DateIssued)
                                           .Where(x => x.DateIssued.Value.Year == year)
                                           .Skip((pageNumber - 1) * pageSize)
                                           .Take(pageSize)
                                           .ToListAsync();

        return tickets;
    }

    public async Task<int> CountAllTickets(int year)
    {
        return await _context.Ticket.Where(x => x.DateIssued.Value.Year == year).AsNoTracking().CountAsync();
    }

    public async Task<Ticket> GetTicket(int ticketId)
    {
        var ticket = await _context.Ticket.AsNoTracking().FirstOrDefaultAsync(x => x.Id == ticketId);

        return ticket;
    }

    public async Task<Ticket> UpdateTicket(Ticket ticket)
    {
        var result = _context.Ticket.Update(ticket);

        await _context.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<decimal?> GetTotalAmount(int year)
    {
        var result = await _context.Ticket.Where(x => x.DateIssued.Value.Year == year).AsNoTracking().SumAsync(x => x.Amount);

        return result;
    }

    public async Task<decimal?> GetTotalAmoutByType(string ticketType, int year)
    {
        var result = await _context.Ticket.AsNoTracking().Where(x => x.DateIssued.Value.Year == year && x.ExpenseType == ticketType).SumAsync(x => x.Amount);

        return result;
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}