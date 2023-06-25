namespace TicketTracker.Shared.Dtos;

public class SignUpResponseDTO
{
    public bool IsRegisterationSuccessful { get; set; }
    public IEnumerable<string> Errors { get; set; }
}