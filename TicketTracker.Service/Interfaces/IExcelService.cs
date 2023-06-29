namespace TicketTracker.Service.Interfaces;

public interface IExcelService
{
    Task<byte[]> GenerateExcelFile();
}