using System.Threading.Tasks;
using CountriesGame.Bll.DTOs;

namespace CountriesGame.Bll.Services.Interfaces
{
    public interface IStatisticService
    {
        Task<StatisticDto> GetStatisticByHeadId(string quizId, string headId);
    }
}