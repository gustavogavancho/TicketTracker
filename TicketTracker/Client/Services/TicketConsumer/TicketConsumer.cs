using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using TicketTracker.Shared.Dtos;
using TicketTracker.Shared.Entities;
using TicketTracker.Shared.Pagination;

namespace TicketTracker.Client.Services.TicketConsumer;

public class TicketConsumer : ITicketConsumer
{
    private readonly HttpClient _httpClient;
    private readonly AuthenticationStateProvider _authStateProvider;

    public TicketConsumer(HttpClient httpClient,
        AuthenticationStateProvider authStateProvider)
    {
        _httpClient = httpClient;
        _authStateProvider = authStateProvider;
    }

    public async Task<TicketDto> CreateTicket(TicketDto ticket)
    {
        var authState = await _authStateProvider.GetAuthenticationStateAsync();
        ticket.Owner = authState.User.Identity.Name;

        var content = JsonConvert.SerializeObject(ticket);

        var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("api/ticket", bodyContent);

        string responseResult = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
            return JsonConvert.DeserializeObject<TicketDto>(responseResult);

        throw new Exception($"Failed to retrieve insert ticket. Status code: {response.StatusCode}");
    }

    public async Task<bool> DeleteTicket(int ticketId)
    {
        var response = await _httpClient.DeleteAsync($"api/ticket/{ticketId}");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<bool>(content);
        }

        throw new Exception($"Failed to retrieve list of tickets. Status code: {response.StatusCode}");
    }

    public async Task<List<TicketDto>> GetAllTickets()
    {
        var response = await _httpClient.GetAsync("api/ticket/getAllTickets");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<TicketDto>>(content);
        }

        throw new Exception($"Failed to retrieve list of tickets. Status code: {response.StatusCode}");
    }

    public async Task<PagingResponse<TicketDto>> GetTicketsByPage(ItemsParameters itemsParameters)
    {
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var queryStringUrl = $"api/ticket?pageNumber={itemsParameters.PageNumber}";

        var response = await _httpClient.GetAsync(queryStringUrl);

        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
        var pagingResponse = new PagingResponse<TicketDto>
        {
            Items = System.Text.Json.JsonSerializer.Deserialize<List<TicketDto>>(content, options),
            MetaData = System.Text.Json.JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), options)
        };
        return pagingResponse;
    }

    public async Task<TicketDto> GetTicket(int ticketId)
    {
        var response = await _httpClient.GetAsync($"api/ticket/{ticketId}");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TicketDto>(content);
        }

        throw new Exception($"Failed to retrieve list of tickets. Status code: {response.StatusCode}");
    }

    public async Task<TicketDto> UpdateTicket(TicketDto ticket)
    {
        var authState = await _authStateProvider.GetAuthenticationStateAsync();
        ticket.Owner = authState.User.Identity.Name;

        var content = JsonConvert.SerializeObject(ticket);

        var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

        var response = await _httpClient.PutAsync("api/ticket/update", bodyContent);

        string responseResult = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
            return JsonConvert.DeserializeObject<TicketDto>(responseResult);

        throw new Exception($"Failed to retrieve insert ticket. Status code: {response.StatusCode}");
    }

    public async Task<byte[]> ExportToExcel()
    {
        var response = await _httpClient.GetAsync("api/ticket/exportTickets");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<byte[]>(content);
        }

        throw new Exception($"Failed to export list of tickets. Status code: {response.StatusCode}");
    }

    public async Task<byte[]> ExportImages()
    {
        var response = await _httpClient.GetAsync("api/ticket/exportImages");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<byte[]>(content);
        }

        throw new Exception($"Failed to export list of tickets. Status code: {response.StatusCode}");
    }

    public async Task<decimal?> GetTotalAmount()
    {
        var response = await _httpClient.GetAsync("api/ticket/getTotalAmount");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<decimal?>(content);
        }

        throw new Exception($"Failed to retrieve list of tickets. Status code: {response.StatusCode}");
    }

    public async Task<decimal?> GetTotalAmoutByType(string ticketType)
    {
        var response = await _httpClient.GetAsync($"api/ticket/getTotalAmount/{ticketType}");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<decimal?>(content);
        }

        throw new Exception($"Failed to retrieve list of tickets. Status code: {response.StatusCode}");
    }
}