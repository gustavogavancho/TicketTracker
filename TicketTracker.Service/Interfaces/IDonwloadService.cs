namespace TicketTracker.Service.Interfaces;

public interface IDonwloadService
{
    Task<byte[]> GenerateExcelFile(int year);
    Task<byte[]> GenerateZipImagesFile(int year);
}