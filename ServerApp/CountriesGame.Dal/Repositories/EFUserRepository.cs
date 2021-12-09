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

        public async Task<User> GetAsync(string userId)
        {
            if (userId == null)
                throw new ArgumentNullException(nameof(userId));

            var user = await _context.Users
                .Include(u => u.Head)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
                return null;

            if (user.Head != null)
                user.Head.SubUsers = null;

            return user;
        }

        public async Task<IEnumerable<User>> GetByHeadIdAsync(string headId)
        {
            if (headId == null)
                throw new ArgumentNullException(nameof(headId));

            var query = _context.Users
                .Where(u => u.HeadId == headId)
                .Include(u => u.Head);

            await query.ForEachAsync(u =>
            {
                if (u.Head != null)
                    u.Head.SubUsers = null;
            });

            return await query.ToListAsync();
        }
    }
}