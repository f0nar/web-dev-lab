using System.Threading.Tasks;
using CountriesGame.Dal.Entities;

namespace CountriesGame.Dal.Repositories.Interfaces
{
    public interface IQuestionRepository
    {
        Task<Question> GetAsync(string id);
    }
}