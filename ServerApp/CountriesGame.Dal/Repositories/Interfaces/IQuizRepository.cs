using System.Collections.Generic;
using System.Threading.Tasks;
using CountriesGame.Dal.Entities;

namespace CountriesGame.Dal.Repositories.Interfaces
{
    public interface IQuizRepository
    {
        Task<Quiz> GetAsync(string id);

        Task<IEnumerable<Quiz>> GetAllAsync();
    }
}