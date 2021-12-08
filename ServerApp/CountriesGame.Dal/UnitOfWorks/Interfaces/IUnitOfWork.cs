using System.Threading.Tasks;
using CountriesGame.Dal.Repositories.Interfaces;

namespace CountriesGame.Dal.UnitOfWorks.Interfaces
{
    public interface IUnitOfWork
    {
        ICountryRepository Countries { get; }

        ILinkRepository Links { get; }

        IUserRepository Users { get; }

        Task SaveChangesAsync();
    }
}