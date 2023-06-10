using AutoMapper;
using PortfolioApi.Entities.User;

namespace PortfolioApi.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, Models.UserDto>();
        }
    }
}
