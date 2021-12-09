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
    public class EFLinkRepository : ILinkRepository
    {
        private readonly ApplicationDbContext _context;

        public EFLinkRepository(ApplicationDbContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;
        }

        public async Task<IEnumerable<Link>> GetByCountryIdAsync(string countryId)
        {
            var query = _context.Links
                .Where(l => l.CountryId == countryId)
                .Include(l => l.Country);

            await query.ForEachAsync(l => 
            {
                if (l.Country != null)
                    l.Country.Links = null;
            });

            return await query.ToListAsync();
        }
    }
}