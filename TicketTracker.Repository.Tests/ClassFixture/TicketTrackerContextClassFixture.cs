using Microsoft.EntityFrameworkCore;
using TicketTracker.Repository.Data;
using TicketTracker.Shared.Entities;

namespace TicketTracker.Repository.Tests.ClassFixture;

public class TicketTrackerContextClassFixture
{
    public TicketTrackerContext Context { get; private set; }

    public TicketTrackerContextClassFixture()
    {
        var options = new DbContextOptionsBuilder<TicketTrackerContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        Context = new TicketTrackerContext(options);

        SeedTicket();
    }

    private void SeedTicket()
    {
        Context.Ticket.Add(new Ticket
        {
            Id = 1,
            TicketNumber = "123456789",
            Description = "Test",
            Nit = 123456789,
            Amount = 200.33m
        });

        Context.Ticket.Add(new Ticket
        {
            Id = 2,
            TicketNumber = "1234567890",
            Description = "Test 2",
            Nit = 1234567890,
            Amount = 200.333m
        });

        Context.SaveChanges();
    }
}