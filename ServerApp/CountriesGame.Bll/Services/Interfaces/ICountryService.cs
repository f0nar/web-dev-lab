using System.Threading.Tasks;
using CountriesGame.Bll.DTOs;

namespace CountriesGame.Bll.Services.Interfaces
{
    public interface ICountryService
    {
        Task<CountryDto> GetCountryAsync(string countryName);

        Task<byte[]> GetFlagAsync(string countryName);

        Task<byte[]> GetCoatAsync(string countryName);

        Task<byte[]> GetAnthemAsync(string countryName);
    }
}