using System.Threading.Tasks;
using CountriesGame.Dal.Entities;

namespace CountriesGame.Dal.Repositories.Interfaces
{
    public interface IOptionRepository
    {
        Task<Option> GetAsync(string id);
    }
}