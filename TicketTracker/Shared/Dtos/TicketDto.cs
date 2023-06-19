using FluentValidation;

namespace TicketTracker.Shared.Dtos;

public class TicketDto
{
    public int Id { get; set; }
    public string TicketNumber { get; set; } = default!;
    public long? Nit { get; set; }
    public string Description { get; set; } = default!;
    public decimal? Amount { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public byte[]? Image { get; set; } = default!;
}

public class TicketValidator : AbstractValidator<TicketDto>
{
    public TicketValidator()
    {
        RuleFor(x => x.TicketNumber).NotEmpty();
        RuleFor(x => x.Nit).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.Amount).NotEmpty().GreaterThan(0);
    }
}