using System.Collections.Generic;
using System.Threading.Tasks;
using CountriesGame.Dal.Entities;

namespace CountriesGame.Dal.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetAsync(string userId);

        Task<IEnumerable<User>> GetByHeadIdAsync(string headId, bool relatedData = false);
    }
}