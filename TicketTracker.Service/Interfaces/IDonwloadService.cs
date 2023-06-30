namespace TicketTracker.Service.Interfaces;

public interface IDonwloadService
{
    Task<byte[]> GenerateExcelFile();
    Task<byte[]> GenerateZipImagesFile();
}