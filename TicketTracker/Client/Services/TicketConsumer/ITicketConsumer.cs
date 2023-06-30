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
    Task<byte[]> ExportToExcel();
    Task<byte[]> ExportImages();
    Task<PagingResponse<TicketDto>> GetTickets(ItemsParameters itemsParameters);
}