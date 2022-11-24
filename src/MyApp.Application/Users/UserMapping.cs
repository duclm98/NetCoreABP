using AutoMapper;
using MyApp.Users.Dto;

namespace MyApp.Users
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<User, LoginDto>()
                .ForMember(u => u.UserId, options => options.MapFrom(input => input.Id))
                .ReverseMap();

            CreateMap<User, RegisterDto>()
                .ForMember(u => u.UserId, options => options.MapFrom(input => input.Id))
                .ReverseMap();
        }
    }
}
