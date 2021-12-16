using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CountriesGame.Bll.DTOs;
using CountriesGame.Bll.Services.Interfaces;
using CountriesGame.Dal.UnitOfWorks.Interfaces;

namespace CountriesGame.Bll.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _db;

        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));
            if (mapper == null)
                throw new ArgumentNullException(nameof(mapper));

            _db = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserDto> GetUserAsync(string userId)
        {
            if (userId == null)
                throw new ArgumentNullException(nameof(userId));

            var user = await _db.Users.GetAsync(userId);

            return user != null ? _mapper.Map<UserDto>(user) : null;
        }

        public async Task<IEnumerable<UserDto>> GetUsersByHeadIdAsync(string headId)
        {
            if (headId == null)
                throw new ArgumentNullException(nameof(headId));

            var users = await _db.Users.GetByHeadIdAsync(headId, true);
            var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);

            return userDtos;
        }
    }
}