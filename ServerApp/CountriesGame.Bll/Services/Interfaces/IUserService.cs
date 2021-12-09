using System.Collections.Generic;
using System.Threading.Tasks;
using CountriesGame.Bll.DTOs;

namespace CountriesGame.Dal.Repositories.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetUserAsync(string userId);

        Task<IEnumerable<UserDto>> GetUsersByHeadIdAsync(string headId);
    }
}