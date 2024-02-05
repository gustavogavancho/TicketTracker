using AutoMapper;
using TicketTracker.Repository.Interfaces;
using TicketTracker.Service.Interfaces;
using TicketTracker.Shared.Dtos;
using TicketTracker.Shared.Entities;
using TicketTracker.Shared.Pagination;

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

    public async Task<IEnumerable<TicketDto>> GetAllTickets(int year)
    {
        var result = _mapper.Map<IEnumerable<TicketDto>>(await _repository.GetAllTickets(year));

        return result;
    }

    public async Task<PagedList<TicketDto>> GetAllTicketsByPage(ItemsParameters itemsParameters)
    {
        Task <IEnumerable<Ticket>> tickets = _repository.GetAllTicketsByPage(itemsParameters.PageNumber, itemsParameters.PageSize, itemsParameters.Year);
        Task<int> countedTickets = _repository.CountAllTickets(itemsParameters.Year);

        await Task.WhenAll(tickets, countedTickets);

        var result = _mapper.Map<List<TicketDto>>(tickets.Result);

        return PagedList<TicketDto>
        .ToPagedList(countedTickets.Result,
                     result, 
                     itemsParameters.PageNumber, 
                     itemsParameters.PageSize);
    }

    public async Task<TicketDto> GetTicket(int ticketId)
    {
        var result = await _repository.GetTicket(ticketId);

        return _mapper.Map<TicketDto>(result);
    }

    public async Task<decimal?> GetTotalAmount(int year)
    {
        var result = await _repository.GetTotalAmount(year);

        return result;
    }

    public async Task<decimal?> GetTotalAmoutByType(string ticketType, int year)
    {
        var result = await _repository.GetTotalAmoutByType(ticketType, year);

        return result;
    }

    public async Task<TicketDto> UpdateTicket(TicketDto ticketDto)
    {
        var ticket = _mapper.Map<Ticket>(ticketDto);

        var result = await _repository.UpdateTicket(ticket);

        return _mapper.Map<TicketDto>(result);
    }
}