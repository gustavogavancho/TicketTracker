using System.ComponentModel.DataAnnotations;

namespace TicketTracker.Shared.Entities;

public class Ticket
{
    public int Id { get; set; }
    [Required] public string TicketNumber { get; set; } = default!;
    [Required] public long? Nit { get; set; }
    [Required] public string Description { get; set; } = default!;
    [Required] public decimal? Amount { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    [Required] public byte[] TicketAttached { get; set; } = default!;
}