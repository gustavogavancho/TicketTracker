using TicketTracker.Shared.Dtos;
using TicketTracker.Shared.Pagination;

namespace TicketTracker.Client.Services.TicketConsumer;

public interface ITicketConsumer
{
    Task<TicketDto> CreateTicket(TicketDto ticket);
    Task<List<TicketDto>> GetAllTickets();
    Task<TicketDto> GetTicket(int ticketId);
    Task<TicketDto> UpdateTicket(TicketDto ticket);
    Task<bool> DeleteTicket(int ticketId);
    Task<byte[]> ExportToExcel(int year);
    Task<byte[]> ExportImages(int year);
    Task<PagingResponse<TicketDto>> GetTicketsByPage(ItemsParameters itemsParameters);
    Task<decimal?> GetTotalAmount(int year);
    Task<decimal?> GetTotalAmoutByType(string ticketType, int year);
}