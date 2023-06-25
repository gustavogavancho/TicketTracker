using Microsoft.AspNetCore.Components;
using TicketTracker.Client.Services.TicketConsumer;

namespace TicketTracker.Client.Pages.Authentication;

public partial class Logout
{
    [Inject]
    public IAuthenticationService _authSerivce { get; set; }
    [Inject]
    public NavigationManager _navigationManager { get; set; }

    protected async override Task OnInitializedAsync()
    {
        await _authSerivce.Logout();
        _navigationManager.NavigateTo("/login");
    }
}