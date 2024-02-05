using TicketTracker.Shared.Dtos;
using TicketTracker.Shared.Pagination;

namespace TicketTracker.Service.Interfaces;

public interface ITicketService
{
    Task<TicketDto> CreateTicket(TicketDto ticketDto);
    Task<TicketDto> GetTicket(int ticketId);
    Task<TicketDto> UpdateTicket(TicketDto ticketDto);
    Task<PagedList<TicketDto>> GetAllTicketsByPage(ItemsParameters itemsParameters);
    Task<IEnumerable<TicketDto>> GetAllTickets(int year);
    Task<bool> DeleteTicket(int ticketId);
    Task<decimal?> GetTotalAmount(int year);
    Task<decimal?> GetTotalAmoutByType(string ticketType, int year);
}