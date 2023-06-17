using Microsoft.EntityFrameworkCore;
using TicketTracker.Shared.Entities;

namespace TicketTracker.Repository.Data;

public class TicketTrackerContext : DbContext
{
    public TicketTrackerContext(DbContextOptions<TicketTrackerContext> options) : base(options)
    {
    }

    public DbSet<Ticket> Ticket { get; set; }
}