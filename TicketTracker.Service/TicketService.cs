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

    public async Task<bool> DeleteTicket(int ticketId)
    {
        var result = await _repository.DeleteTicket(ticketId);

        return result;
    }

    public async Task<List<TicketDto>> GetAllTickets()
    {
        var result = _mapper.Map<List<TicketDto>>(await _repository.GetAllTickets());

        return result;
    }

    public async Task<TicketDto> GetTicket(int ticketId)
    {
        var result = await _repository.GetTicket(ticketId);

        return _mapper.Map<TicketDto>(result);
    }

    public async Task<TicketDto> UpdateTicket(TicketDto ticketDto)
    {
        var ticket = _mapper.Map<Ticket>(ticketDto);

        var result = await _repository.UpdateTicket(ticket);

        return _mapper.Map<TicketDto>(result);
    }
}