using System;
using System.Threading.Tasks;
using CountriesGame.Dal.DbContext;
using CountriesGame.Dal.Repositories;
using CountriesGame.Dal.Repositories.Interfaces;
using CountriesGame.Dal.UnitOfWorks.Interfaces;

namespace CountriesGame.Dal.UnitOfWorks
{
    public class EFUnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;

        private ICountryRepository _countryRepository;
        private ILinkRepository _linkRepository;
        private IUserRepository _userRepository;

        public EFUnitOfWork(ApplicationDbContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;
        }

        public ICountryRepository Countries =>
            _countryRepository ??= new EFCountryRepository(_context);

        public ILinkRepository Links =>
            _linkRepository ??= new EFLinkRepository(_context);

        public IUserRepository Users =>
            _userRepository ??= new EFUserRepository(_context);

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}