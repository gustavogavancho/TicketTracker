using Microsoft.EntityFrameworkCore;
using TicketTracker.Repository.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<TicketTrackerContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("TicketTrackerContext") ?? throw new InvalidOperationException("Connection string 'TicketTrackerServerContext' not found.")));

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