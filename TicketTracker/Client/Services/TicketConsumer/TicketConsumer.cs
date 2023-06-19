using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;
using System.Text;
using TicketTracker.Shared.Dtos;

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

        return null;
    }

    public async Task<string> UploadImage(int ticketId, IBrowserFile ticketImage)
    {
        var fileContent = ticketImage.OpenReadStream(ticketImage.Size);

        using var content = new MultipartFormDataContent();
        content.Add(new StreamContent(fileContent), "image", ticketImage.Name);

        var response = await _httpClient.PostAsync($"api/ticket/{ticketId}/image", content);

        string responseResult = await response.Content.ReadAsStringAsync();

        return responseResult;
    }
}