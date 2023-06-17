using AutoMapper;
using TicketTracker.Repository.Interfaces;
using TicketTracker.Service.Interfaces;
using TicketTracker.Shared.Dtos;

namespace TicketTracker.Service;

public class TicketService : ITicketService
{
    private readonly ITicketRepository _repository;
    private readonly IMapper _mapper;

    public TicketService(ITicketRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<TicketDto> CreateTicket(TicketDto ticketDto)
    {
        throw new NotImplementedException();
    }
}