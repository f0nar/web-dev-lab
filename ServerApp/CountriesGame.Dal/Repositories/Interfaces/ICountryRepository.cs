using System.Threading.Tasks;
using CountriesGame.Dal.Entities;

namespace CountriesGame.Dal.Repositories.Interfaces
{
    public interface ICountryRepository
    {
        Task<Country> GetAsync(string id);

        Task<Country> GetByNameAsync(string name);
    }
}