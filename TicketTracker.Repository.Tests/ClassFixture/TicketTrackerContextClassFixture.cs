using Microsoft.EntityFrameworkCore;
using TicketTracker.Repository.Data;

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
    }
}