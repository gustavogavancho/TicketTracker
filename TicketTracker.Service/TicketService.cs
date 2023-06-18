using AutoMapper;
using TicketTracker.Repository.Interfaces;
using TicketTracker.Service.Interfaces;
using TicketTracker.Shared.Dtos;
using TicketTracker.Shared.Entities;

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

    public async Task<TicketDto> CreateTicket(TicketDto ticketDto)
    {
        var ticket = await _repository.CreateTicket(_mapper.Map<Ticket>(ticketDto));

        return _mapper.Map<TicketDto>(ticket);
    }

    public Task<TicketDto> GetTicket(int ticketId)
    {
        throw new NotImplementedException();
    }
}