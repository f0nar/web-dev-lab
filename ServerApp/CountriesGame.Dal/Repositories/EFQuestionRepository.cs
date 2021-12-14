using System;
using System.Threading.Tasks;
using CountriesGame.Dal.DbContext;
using CountriesGame.Dal.Entities;
using CountriesGame.Dal.Repositories.Interfaces;

namespace CountriesGame.Dal.Repositories
{
    public class EFQuestionRepository : IQuestionRepository
    {
        private readonly ApplicationDbContext _context;

        public EFQuestionRepository(ApplicationDbContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;
        }

        public async Task<Question> GetAsync(string id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            var questions = await _context.Questions.FindAsync(id);

            return questions;
        }
    }
}