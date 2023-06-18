using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using TicketTracker.Repository;
using TicketTracker.Repository.Data;
using TicketTracker.Repository.Interfaces;
using TicketTracker.Service;
using TicketTracker.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation(options =>
{
    options.DisableDataAnnotationsValidation = true;
});
builder.Services.AddRazorPages();
builder.Services.AddDbContext<TicketTrackerContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("TicketTrackerContext") ?? throw new InvalidOperationException("Connection string 'TicketTrackerServerContext' not found.")));

builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<ITicketService, TicketService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();