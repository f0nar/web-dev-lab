using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CountriesGame.Bll.DTOs;
using CountriesGame.Bll.Exceptions;
using CountriesGame.Bll.Infrastructure;
using CountriesGame.Bll.Services.Interfaces;
using CountriesGame.Dal.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CountriesGame.Bll.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;

        private readonly AuthOptions _authOptions;

        private readonly IMapper _mapper;

        public AuthService(UserManager<User> userManager,
            IOptions<AuthOptions> authOptions, IMapper mapper)
        {
            if (userManager == null)
                throw new ArgumentNullException(nameof(userManager));
            if (authOptions == null)
                throw new ArgumentNullException(nameof(authOptions));
            if (mapper == null)
                throw new ArgumentNullException(nameof(mapper));

            _userManager = userManager;
            _authOptions = authOptions.Value;
            _mapper = mapper;
        }

        public async Task<UserDto> RegisterAsync(RegisterDto registerDto, string headId = null)
        {
            if (registerDto == null)
                throw new ArgumentNullException(nameof(registerDto));

            var user = _mapper.Map<User>(registerDto);

            var creationResult = await _userManager.CreateAsync(user, registerDto.Password);
            if (!creationResult.Succeeded)
                throw new IdentityException(creationResult.ToString(), creationResult.Errors);

            var roleAddingResult = await _userManager.AddToRoleAsync(user, "Student");
            if (!roleAddingResult.Succeeded)
                throw new IdentityException(creationResult.ToString(), roleAddingResult.Errors);

            if (headId != null)
            {
                user.HeadId = headId;
                var updateResult = await _userManager.UpdateAsync(user);
                if (!updateResult.Succeeded)
                    throw new IdentityException(updateResult.ToString(), updateResult.Errors);
            }

            return _mapper.Map<UserDto>(user);
        }

        public async Task<string> LoginAsync(LoginDto loginDto)
        {
            if (loginDto == null)
                throw new ArgumentNullException(nameof(loginDto));

            var user = await _userManager.FindByNameAsync(loginDto.UserName);
            if (user == null)
                throw new EntityNotFoundException("User with specified UserName not found");

            var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!result)
                throw new IdentityException("Error occured while checking password");

            var token = await GetTokenAsync(user);
            return token;
        }

        public async Task<bool> IsInRoleAsync(string userId, string role)
        {
            if (userId == null)
                throw new ArgumentNullException(nameof(userId));
            if (role == null)
                throw new ArgumentNullException(nameof(role));

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                throw new EntityNotFoundException("User with specified UserName not found");

            return await _userManager.IsInRoleAsync(user, role);
        }

        public async Task ChangePasswordAsync(ChangePasswordDto changePasswordDto)
        {
            if (changePasswordDto == null)
                throw new ArgumentNullException(nameof(changePasswordDto));

            var user = await _userManager.FindByIdAsync(changePasswordDto.Id);
            if (user == null)
                throw new EntityNotFoundException("User with specified Id not found");

            var result = await _userManager.ChangePasswordAsync(user,
                changePasswordDto.CurrentPassword, changePasswordDto.NewPassword);
            if (!result.Succeeded)
                throw new IdentityException(result.ToString(), result.Errors);
        }

        public async Task ConfirmPassword(string userId)
        {
            if (userId == null)
                throw new ArgumentNullException(userId);

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                throw new EntityNotFoundException("User with specified Id not found");

            user.PasswordConfirmed = true;
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
                throw new IdentityException(result.ToString(), result.Errors);
        }

        private async Task<string> GetTokenAsync(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var tokenKey = _authOptions.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(tokenKey, SecurityAlgorithms.HmacSha256);
            var now = DateTime.UtcNow;

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims, "Token"),
                SigningCredentials = credentials,
                NotBefore = now,
                Expires = now.AddMinutes(_authOptions.AccessExpiration),
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(securityTokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}