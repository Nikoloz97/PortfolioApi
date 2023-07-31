using AutoMapper;
using PortfolioApi.Entities.User;
using PortfolioApi.Models.User;

namespace PortfolioApi.Profiles.User
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<PortfolioApi.Entities.User.User, UserDto>();
            CreateMap<UserDto, Entities.User.User>().ReverseMap();
        }
    }
}
