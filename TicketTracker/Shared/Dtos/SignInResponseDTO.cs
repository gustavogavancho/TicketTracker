﻿namespace TicketTracker.Shared.Dtos;

public class SignInResponseDTO
{
    public bool IsAuthSuccessful { get; set; }
    public string ErrorMessage { get; set; }
    public string Token { get; set; }
    public UserDTO UserDTO { get; set; }
}