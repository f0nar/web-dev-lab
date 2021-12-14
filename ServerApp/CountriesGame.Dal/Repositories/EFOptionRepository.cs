using System;
using System.Threading.Tasks;
using CountriesGame.Dal.DbContext;
using CountriesGame.Dal.Entities;
using CountriesGame.Dal.Repositories.Interfaces;

namespace CountriesGame.Dal.Repositories
{
    public class EFOptionRepository : IOptionRepository
    {
        private readonly ApplicationDbContext _context;

        public EFOptionRepository(ApplicationDbContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;
        }

        public async Task<Option> GetAsync(string id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            var option = await _context.Options.FindAsync(id);

            return option;
        }
    }
}