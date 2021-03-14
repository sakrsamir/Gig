using AutoMapper;
using Gighub.Dtos;
using Gighub.Models;

namespace Gighub.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Notification, NotificationDto>();
            Mapper.CreateMap<Gig, GigDto>();
            Mapper.CreateMap<ApplicationUser, UserDto>();
        }
    }
}