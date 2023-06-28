using TicketTracker.Shared.Dtos;
using TicketTracker.Shared.Pagination;

namespace TicketTracker.Service.Interfaces;

public interface ITicketService
{
    Task<TicketDto> CreateTicket(TicketDto ticketDto);
    Task<TicketDto> GetTicket(int ticketId);
    Task<TicketDto> UpdateTicket(TicketDto ticketDto);
    Task<PagedList<TicketDto>> GetAllTickets(ItemsParameters itemsParameters);
    Task<bool> DeleteTicket(int ticketId);
}