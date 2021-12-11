using System.Threading.Tasks;
using CountriesGame.Bll.DTOs;

namespace CountriesGame.Bll.Services.Interfaces
{
    public interface IAuthService
    {
        Task<UserDto> RegisterAsync(RegisterDto registerDto);

        Task<string> LoginAsync(LoginDto loginDto);

        Task<bool> IsInRoleAsync(string userId, string role);

        Task ChangePasswordAsync(ChangePasswordDto changePasswordDto);

        Task ConfirmPassword(string userId);
    }
}