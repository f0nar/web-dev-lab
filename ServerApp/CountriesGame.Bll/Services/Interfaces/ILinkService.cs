using System.Collections.Generic;
using System.Threading.Tasks;
using CountriesGame.Bll.DTOs;

namespace CountriesGame.Bll.Services.Interfaces
{
    public interface ILinkService
    {
        Task<IEnumerable<LinkDto>> GetLinksByCountryIdAsync(string countryId);
    }
}