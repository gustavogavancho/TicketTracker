using FluentValidation;

namespace TicketTracker.Shared.Dtos;

public class TicketDto
{
    public string TicketNumber { get; set; } = default!;
    public long? Nit { get; set; }
    public string Description { get; set; } = default!;
    public decimal? Amount { get; set; }
    public ImageAction ImageAction { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public string? Image { get; set; } = default!;
}

public enum ImageAction
{
    None,
    Add,
    Remove
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