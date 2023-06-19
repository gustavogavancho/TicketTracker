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
        var result = await _repository.CreateTicket(_mapper.Map<Ticket>(ticketDto));

        return _mapper.Map<TicketDto>(result);
    }

    public async Task<TicketDto> GetTicket(int ticketId, bool trackChanges)
    {
        var result = await _repository.GetTicket(ticketId, trackChanges);

        return _mapper.Map<TicketDto>(result);
    }

    public async Task<TicketDto> UpdateTicket(int ticketId, TicketDto ticketDto)
    {
        var ticket = _mapper.Map<Ticket>(ticketDto);

        var result = await _repository.UpdateTicket(ticket);

        return _mapper.Map<TicketDto>(result);
    }
}