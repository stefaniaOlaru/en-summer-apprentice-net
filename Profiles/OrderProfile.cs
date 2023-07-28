using AutoMapper;
using TicketManagementSystem.Models;
using TicketManagementSystem.Models.dto;

namespace TicketManagementSystem.Profiles
{
    public class OrderProfile: Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, OrderPatchDto>().ReverseMap();
        }
    }
}
