using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CountriesGame.Dal.DbContext;
using CountriesGame.Dal.Entities;
using CountriesGame.Dal.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CountriesGame.Dal.Repositories
{
    public class EFUserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public EFUserRepository(ApplicationDbContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;
        }

        public async Task<User> Get(string userId)
        {
            if (userId == null)
                throw new ArgumentNullException(nameof(userId));

            return await _context.Users.FindAsync(userId);
        }

        public async Task<IEnumerable<User>> GetByHeadId(string headId)
        {
            if (headId == null)
                throw new ArgumentNullException(nameof(headId));

            var query = _context.Users
                .Where(u => u.HeadId == headId);

            return await query.ToListAsync();
        }
    }
}