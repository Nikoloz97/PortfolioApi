using AutoMapper;
using PortfolioApi.Entities.User;
using PortfolioApi.Models.User;

namespace PortfolioApi.Profiles.User
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<PortfolioApi.Entities.User.User, UserDto_Return>();
            CreateMap<UserDto_Return, Entities.User.User>().ReverseMap();
            CreateMap<UserDto_Creation, Entities.User.User>();
        }
    }
}
