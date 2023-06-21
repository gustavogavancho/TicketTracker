using AutoFixture;
using AutoMapper;
using Moq;
using TicketTracker.Repository.Interfaces;
using TicketTracker.Service.Profiles;
using TicketTracker.Shared.Dtos;
using TicketTracker.Shared.Entities;

namespace TicketTracker.Service.Tests;

public class TicketServiceTests
{
    private readonly Fixture _fixture;
    private readonly Mock<ITicketRepository> _repository;
    private readonly Mapper _mapper;
    private readonly TicketService _service;

    public TicketServiceTests()
    {
        _fixture = new Fixture();
        _repository = new Mock<ITicketRepository>();
        _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<TicketTrackerProfiles>()));
        _service = new TicketService(_repository.Object, _mapper);
    }

    [Fact]
    public async Task TicketServiceTests_CreateTicket_Successfully()
    {
        //Arrange
        var ticketDto = _fixture.Create<TicketDto>();

        _repository.Setup(x => x.CreateTicket(It.IsAny<Ticket>())).ReturnsAsync(_mapper.Map<Ticket>(ticketDto));

        //Act
        var sut = await _service.CreateTicket(ticketDto);

        //Assert
        Assert.NotNull(sut);
        Assert.IsType<TicketDto>(sut);
    }

    [Fact]
    public async Task TicketServiceTests_GetTicket_Successfully()
    {
        //Arrange
        var ticketDto = _fixture.Create<TicketDto>();

        _repository.Setup(x => x.GetTicket(It.IsAny<int>())).ReturnsAsync(_mapper.Map<Ticket>(ticketDto));

        //Act
        var sut = await _service.GetTicket(It.IsAny<int>());

        //Assert
        Assert.NotNull(sut);
        Assert.IsType<TicketDto>(sut);
    }

    [Fact]
    public async Task TicketServiceTests_UpdateTicket_Successfully()
    {
        //Arrange
        var ticketDto = _fixture.Create<TicketDto>();

        _repository.Setup(x => x.UpdateTicket(It.IsAny<Ticket>())).ReturnsAsync(_mapper.Map<Ticket>(ticketDto));

        //Act
        var sut = await _service.UpdateTicket(ticketDto);

        //Assert
        Assert.NotNull(sut);
        Assert.IsType<TicketDto>(sut);
    }

    [Fact]
    public async Task TicketServiceTests_GetAllTickets_Successfully()
    {
        //Arrange
        var tickets = _fixture.Create<List<Ticket>>();

        _repository.Setup(x => x.GetAllTickets()).ReturnsAsync(tickets);

        //Act
        var sut = await _service.GetAllTickets();

        //Assert
        Assert.NotNull(sut);
        Assert.IsType<List<TicketDto>>(sut);
    }

    [Fact]
    public async Task TicketServiceTests_DeleteTicket_Successfully()
    {
        //Arrange

        _repository.Setup(x => x.DeleteTicket(It.IsAny<int>())).ReturnsAsync(true);

        //Act
        var sut = await _service.DeleteTicket(It.IsAny<int>());

        //Assert
        Assert.IsType<bool>(sut);
        Assert.True(sut);
    }
}