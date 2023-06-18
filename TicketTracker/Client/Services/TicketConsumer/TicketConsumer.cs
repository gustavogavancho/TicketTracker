﻿using Newtonsoft.Json;
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
        TicketDto result = null;

        var content = JsonConvert.SerializeObject(ticket);

        var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("api/ticket", bodyContent);

        string responseResult = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
            result = JsonConvert.DeserializeObject<TicketDto>(responseResult);

        return result;
    }
}