using FluentValidation;

namespace TicketTracker.Shared.Dtos;

public class SignUpRequestDTO
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}

public class SignUpRequestValidator : AbstractValidator<SignUpRequestDTO>
{
    public SignUpRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty();
        RuleFor(x => x.ConfirmPassword).NotEmpty().Equal(x => x.Password).WithMessage("Passwords do not match.");
    }
}