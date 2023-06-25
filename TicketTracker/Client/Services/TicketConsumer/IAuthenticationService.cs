using TicketTracker.Shared.Dtos;

namespace TicketTracker.Client.Services.TicketConsumer;

public interface IAuthenticationService
{
    Task<SignUpResponseDTO> RegisterUser(SignUpRequestDTO signUpRequestDTO);
    Task<SignInResponseDTO> Login(SignInRequestDTO signInRequestDTO);
    Task Logout();
}