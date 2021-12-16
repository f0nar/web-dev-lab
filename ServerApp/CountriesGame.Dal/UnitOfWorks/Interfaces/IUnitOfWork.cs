using System.Threading.Tasks;
using CountriesGame.Dal.Repositories.Interfaces;

namespace CountriesGame.Dal.UnitOfWorks.Interfaces
{
    public interface IUnitOfWork
    {
        ICountryRepository Countries { get; }

        ILinkRepository Links { get; }

        IUserRepository Users { get; }

        IQuizRepository Quizzes { get; }

        IQuestionRepository Questions { get; }

        IOptionRepository Options { get; }

        ISubmittedQuizRepository SubmittedQuizzes { get; }

        Task SaveChangesAsync();
    }
}