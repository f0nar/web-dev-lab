using System.Collections.Generic;
using System.Threading.Tasks;
using CountriesGame.Dal.Entities;

namespace CountriesGame.Dal.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Get(string userId);

        Task<IEnumerable<User>> GetByHeadId(string headId);
    }
}