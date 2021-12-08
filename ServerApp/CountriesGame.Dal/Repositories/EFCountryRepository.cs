using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CountriesGame.Dal.DbContext;
using CountriesGame.Dal.Entities;
using CountriesGame.Dal.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CountriesGame.Dal.Repositories
{
    public class EFCountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _context;

        public EFCountryRepository(ApplicationDbContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;
        }

        public async Task<Country> Get(string id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            var country = await _context.Countries
                .Include(c => c.Links)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (country == null)
                return null;

            if (country.Links != null)
            {
                foreach (var l in country.Links)
                {
                    l.Country = null;
                }
            }

            return country;
        }

        public async Task<Country> GetByName(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            var country = await _context.Countries
                .Include(c => c.Links)
                .FirstOrDefaultAsync(c => c.CountryName == name);

            if (country == null)
                return null;

            if (country.Links != null)
            {
                foreach (var l in country.Links)
                {
                    l.Country = null;
                }
            }

            return country;
        }
    }
}