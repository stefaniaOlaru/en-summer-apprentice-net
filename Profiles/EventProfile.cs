using AutoMapper;
using TicketManagementSystem.Models;
using TicketManagementSystem.Models.dto;

namespace TicketManagementSystem.Profiles
{
    public class EventProfile: Profile
    {
        public EventProfile() { 
            CreateMap<Event, EventDto>().ReverseMap();
            CreateMap<Event, EventPatchDto>().ReverseMap();
        }
    }
}
