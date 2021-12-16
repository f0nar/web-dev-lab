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
    public class EFQuizRepository : IQuizRepository
    {
        private readonly ApplicationDbContext _context;

        public EFQuizRepository(ApplicationDbContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;
        }
        
        public async Task<Quiz> GetAsync(string id, bool relatedData = false)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            IQueryable<Quiz> query = _context.Quizzes;
            if (relatedData)
            {
                query = query.Include(q => q.Questions)
                    .ThenInclude(q => q.Options);
            }

            var quiz = await query
                .FirstOrDefaultAsync(q => q.Id == id);
            if (quiz == null)
                return null;

            if (quiz.Questions != null)
            {
                foreach (var question in quiz.Questions)
                {
                    question.Quiz = null;
                    if (question.Options != null)
                    {
                        foreach (var option in question.Options)
                        {
                            option.Question = null;
                        }
                    }
                }
            }

            return quiz;
        }

        public async Task<IEnumerable<Quiz>> GetAllAsync()
        {
            return await _context.Quizzes.ToListAsync();
        }
    }
}