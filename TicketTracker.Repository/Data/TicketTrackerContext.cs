using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TicketTracker.Shared.Entities;

namespace TicketTracker.Repository.Data;

public class TicketTrackerContext : IdentityDbContext
{
    public TicketTrackerContext(DbContextOptions<TicketTrackerContext> options) : base(options)
    {
    }

    public DbSet<Ticket> Ticket { get; set; }
    public DbSet<IdentityUser> ApplicationUsers { get; set; }
}