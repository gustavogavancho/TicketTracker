using FluentValidation;

namespace TicketTracker.Shared.Dtos;

public class SignInRequestDTO
{
    public string UserName { get; set; }


    public string Password { get; set; }
}

public class SignInRequestValidator : AbstractValidator<SignInRequestDTO>
{
    public SignInRequestValidator()
    {
        RuleFor(x => x.UserName).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty();
    }
}