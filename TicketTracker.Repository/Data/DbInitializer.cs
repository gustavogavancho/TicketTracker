using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TicketTracker.Repository.Data.Interfaces;
using TicketTracker.Shared;

namespace TicketTracker.Repository.Data;

public class DbInitializer : IDbInitializer
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly TicketTrackerContext _context;

    public DbInitializer(UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager,
        TicketTrackerContext context)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _context = context;
    }

    public async Task Initialize()
    {
        if((await _context.Database.GetPendingMigrationsAsync()).Count() > 0)
        {
            await _context.Database.MigrateAsync();
        }
        if(!(await _roleManager.RoleExistsAsync(SD.Role_Admin)))
        {
            await _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin));
            await _roleManager.CreateAsync(new IdentityRole(SD.Role_Customer));
        }
        else
        {
            return;
        }

        IdentityUser user = new()
        {
            UserName = "ggavanch@gmail.com",
            Email = "ggavancholeon@gmail.com",
            EmailConfirmed = true
        };

        await _userManager.CreateAsync(user, "Gustavo1@@@");

        await _userManager.AddToRoleAsync(user, SD.Role_Admin);
    }
}