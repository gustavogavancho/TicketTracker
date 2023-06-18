using AutoFixture;
using TicketTracker.Repository.Tests.ClassFixture;
using TicketTracker.Shared.Entities;

namespace TicketTracker.Repository.Tests;

public class TicketRepositoryTests : IClassFixture<TicketTrackerContextClassFixture>
{
    private readonly TicketTrackerContextClassFixture _contextFixture;
    private readonly Fixture _fixture;
    private readonly TicketRepository _repository;

    public TicketRepositoryTests(TicketTrackerContextClassFixture contextFixture)
    {
        _contextFixture = contextFixture;
        _fixture = new Fixture();   
        _repository = new TicketRepository(_contextFixture.Context);
    }

    [Fact]
    public async Task TicketRepository_CreateTicket_Successfully()
    {
        //Arrange
        var ticket = _fixture.Create<Ticket>();

        //Act
        var sut = await _repository.CreateTicket(ticket);
        
        //Assert
        Assert.NotNull(sut);
        Assert.IsType<Ticket>(sut);
    }

    [Fact]
    public async Task TicketRepository_GetTicket_Successfully()
    {
        //Arrange

        //Act
        var sut = await _repository.GetTicket(1);

        //Assert
        Assert.NotNull(sut);
        Assert.IsType<Ticket>(sut);
    }
}