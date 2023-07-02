using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using TicketTracker.Shared.Entities;

namespace TicketTracker.Repository.Data;

public class TicketTrackerContext : IdentityDbContext
{
    public TicketTrackerContext(DbContextOptions<TicketTrackerContext> options) : base(options)
    {
    }

    public DbSet<Ticket> Ticket { get; set; }
    public DbSet<IdentityUser> ApplicationUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Ticket>()
            .Property(e => e.Amount)
            .HasConversion<double>();
    }
}