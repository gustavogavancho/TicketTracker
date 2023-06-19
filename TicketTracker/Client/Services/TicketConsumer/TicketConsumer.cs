using Newtonsoft.Json;
using System.Text;
using TicketTracker.Shared.Dtos;
using TicketTracker.Shared.Entities;

namespace TicketTracker.Client.Services.TicketConsumer;

public class TicketConsumer : ITicketConsumer
{
    private readonly HttpClient _httpClient;

    public TicketConsumer(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<TicketDto> CreateTicket(TicketDto ticket)
    {
        var content = JsonConvert.SerializeObject(ticket);

        var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("api/ticket", bodyContent);

        string responseResult = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
            return JsonConvert.DeserializeObject<TicketDto>(responseResult);

        // Handle error
        throw new Exception($"Failed to retrieve insert ticket. Status code: {response.StatusCode}");
    }

    public async Task<List<TicketDto>> GetAllTickets()
    {
        var response = await _httpClient.GetAsync("api/ticket");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<TicketDto>>(content);
        }

        // Handle error
        throw new Exception($"Failed to retrieve list of tickets. Status code: {response.StatusCode}");
    }
}