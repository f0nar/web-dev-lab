using System.Collections.Generic;
using System.Threading.Tasks;
using CountriesGame.Dal.Entities;

namespace CountriesGame.Dal.Repositories.Interfaces
{
    public interface ILinkRepository
    {
        Task<IEnumerable<Link>> GetByCountryIdAsync(string countryId);
    }
}