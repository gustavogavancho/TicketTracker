using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;
using TicketTracker.Repository.Interfaces;
using TicketTracker.Service.Interfaces;
using TicketTracker.Shared.Entities;

namespace TicketTracker.Service;

public class ExcelService : IExcelService
{
    private readonly ITicketRepository _ticketRepository;

    public ExcelService(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<byte[]> GenerateExcelFile()
    {
        using MemoryStream memStream = new MemoryStream();

        using (SpreadsheetDocument document = SpreadsheetDocument.Create(memStream, SpreadsheetDocumentType.Workbook))
        {
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

            // Add header row
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
            foreach (var item in await _ticketRepository.GetAllTickets())
            {
                Row dataRow = new Row();
                foreach (var property in typeof(Ticket).GetProperties())
                {
                    if (property.Name == "Image") continue;
                    Cell cell = new Cell
                    {
                        DataType = CellValues.String,
                        CellValue = new CellValue(property.GetValue(item)?.ToString() ?? "")
                    };
                    dataRow.AppendChild(cell);
                }
                sheetData.AppendChild(dataRow);
            }

            workbookPart.Workbook.Save();
            document.Close();
        }

        return memStream.ToArray();
    }
}