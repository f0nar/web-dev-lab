using System.Collections.Generic;
using System.Threading.Tasks;
using CountriesGame.Dal.Entities;

namespace CountriesGame.Dal.Repositories.Interfaces
{
    public interface ISubmittedQuizRepository
    {
        Task<SubmittedQuiz> GetAsync(string id);

        Task<IEnumerable<SubmittedQuiz>> GetByUserIdAsync(string userId);

        Task<IEnumerable<SubmittedQuiz>> GetByQuizIdAsync(string quizId);

        Task AddAsync(SubmittedQuiz submittedQuiz);
    }
}