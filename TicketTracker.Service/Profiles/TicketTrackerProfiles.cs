using AutoMapper;
using TicketTracker.Shared.Dtos;
using TicketTracker.Shared.Entities;

namespace TicketTracker.Service.Profiles;

public class TicketTrackerProfiles : Profile
{
    public TicketTrackerProfiles()
    {
        CreateMap<Ticket, TicketDto>().ReverseMap();
    }
}