using AutoMapper;
using CountriesGame.Bll.DTOs;
using CountriesGame.Dal.Entities;

namespace CountriesGame.Bll.Infrastructure
{
    public class BetweenDalAndBllMapperProfile : Profile
    {
        public BetweenDalAndBllMapperProfile()
        {
            CreateCountryMap();
            CreateLinkMap();
            CreateUserMap();
        }

        private void CreateCountryMap()
        {
            CreateMap<Country, CountryDto>();
        }

        private void CreateLinkMap()
        {
            CreateMap<Link, LinkDto>();
        }

        private void CreateUserMap()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<LoginDto, User>();
            CreateMap<RegisterDto, User>();
            CreateMap<ChangePasswordDto, User>();
        }
    }
}