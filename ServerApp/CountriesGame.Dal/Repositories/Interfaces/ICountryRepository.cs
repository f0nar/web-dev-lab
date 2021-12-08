using System.Threading.Tasks;
using CountriesGame.Dal.Entities;

namespace CountriesGame.Dal.Repositories.Interfaces
{
    public interface ICountryRepository
    {
        Task<Country> Get(string id);

        Task<Country> GetByName(string name);
    }
}