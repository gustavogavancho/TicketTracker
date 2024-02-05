using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;
using TicketTracker.Repository.Interfaces;
using TicketTracker.Service.Interfaces;
using TicketTracker.Shared.Entities;
using System.IO.Compression;

namespace TicketTracker.Service;

public class DownloadService : IDonwloadService
{
    private readonly ITicketRepository _ticketRepository;

    public DownloadService(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<byte[]> GenerateExcelFile(int year)
    {
        using MemoryStream memStream = new MemoryStream();

        using SpreadsheetDocument document = SpreadsheetDocument.Create(memStream, SpreadsheetDocumentType.Workbook);

        WorkbookPart workbookPart = document.AddWorkbookPart();
        workbookPart.Workbook = new Workbook();

        WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
        worksheetPart.Worksheet = new Worksheet(new SheetData());

        Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
        Sheet sheet = new Sheet()
        {
            Id = workbookPart.GetIdOfPart(worksheetPart),
            SheetId = 1,
            Name = "Sheet1"
        };
        sheets.Append(sheet);

        SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

        Row headerRow = new Row();
        foreach (var property in typeof(Ticket).GetProperties())
        {
            if (property.Name == "Image") continue;
            Cell cell = new Cell
            {
                DataType = CellValues.String,
                CellValue = new CellValue(property.Name)
            };
            headerRow.AppendChild(cell);
        }
        sheetData.AppendChild(headerRow);

        // Add data rows
        foreach (var item in await _ticketRepository.GetAllTickets(year))
        {
            Row dataRow = new Row();
            foreach (var property in typeof(Ticket).GetProperties())
            {
                if (property.Name == "Image") continue;
                Cell cell = new Cell
                {
                    DataType = property.Name == "Amount" ? CellValues.Number : CellValues.String,
                    CellValue = new CellValue(property.GetValue(item)?.ToString() ?? "")
                };
                dataRow.AppendChild(cell);
            }
            sheetData.AppendChild(dataRow);
        }

        workbookPart.Workbook.Save();
        document.Close();

        return memStream.ToArray();
    }

    public async Task<byte[]> GenerateZipImagesFile(int year)
    {
        var tickets = await _ticketRepository.GetAllTickets(year);

        using var memoryStream = new MemoryStream();

        using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
        {
            var tasks = tickets
                .Where(ticket => ticket.Image != null)
                .Select(async ticket =>
                {
                    var entryName = $"{ticket.DateIssued.Value.ToString("dd-MM-yy")}_{ticket.TicketNumber}_{ticket.Nit}.jpg";
                    var entry = archive.CreateEntry(entryName, CompressionLevel.Optimal);

                    using var entryStream = entry.Open();
                    await entryStream.WriteAsync(ticket.Image, 0, ticket.Image.Length);
                });

            await Task.WhenAll(tasks);
        }

        memoryStream.Position = 0;

        return memoryStream.ToArray();
    }
}