using System.Collections.Generic;
using System.Threading.Tasks;
using CountriesGame.Bll.DTOs;

namespace CountriesGame.Bll.Services.Interfaces
{
    public interface IQuizService
    {
        Task<QuizDto> GetQuizAsync(string id);

        Task<IEnumerable<QuizDto>> GetQuizzesAsync();
    }
}