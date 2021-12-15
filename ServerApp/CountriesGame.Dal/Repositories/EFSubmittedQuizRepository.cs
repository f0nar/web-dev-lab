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
    public class EFSubmittedQuizRepository : ISubmittedQuizRepository
    {
        private readonly ApplicationDbContext _context;

        public EFSubmittedQuizRepository(ApplicationDbContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;
        }

        public async Task<SubmittedQuiz> GetAsync(string id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            var submittedQuiz = await _context.SubmittedQuizzes
                .Include(sq => sq.SubmittedQuestions)
                .ThenInclude(sq => sq.SubmittedOptions)
                .FirstOrDefaultAsync(sq => sq.Id == id);
            if (submittedQuiz == null)
                return null;

            if (submittedQuiz.SubmittedQuestions != null)
            {
                foreach (var question in submittedQuiz.SubmittedQuestions)
                {
                    question.SubmittedQuiz = null;
                    if (question.SubmittedOptions != null)
                    {
                        foreach (var option in question.SubmittedOptions)
                        {
                            option.SubmittedQuestion = null;
                        }
                    }
                }
            }

            return submittedQuiz;
        }

        public async Task<IEnumerable<SubmittedQuiz>> GetByUserIdAsync(string userId)
        {
            if (userId == null)
                throw new ArgumentNullException(nameof(userId));

            var query = _context.SubmittedQuizzes
                .Where(sq => sq.UserId == userId)
                .Include(sq => sq.SubmittedQuestions)
                .ThenInclude(sq => sq.SubmittedOptions);

            await query.ForEachAsync(sq =>
            {
                if (sq.SubmittedQuestions != null)
                {
                    foreach (var question in sq.SubmittedQuestions)
                    {
                        question.SubmittedQuiz = null;
                        if (question.SubmittedOptions != null)
                        {
                            foreach (var option in question.SubmittedOptions)
                            {
                                option.SubmittedQuestion = null;
                            }
                        }
                    }
                }
            });

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<SubmittedQuiz>> GetByQuizIdAsync(string quizId)
        {
            if (quizId == null)
                throw new ArgumentNullException(nameof(quizId));

            var query = _context.SubmittedQuizzes
                .Where(sq => sq.QuizId == quizId)
                .Include(sq => sq.SubmittedQuestions)
                .ThenInclude(sq => sq.SubmittedOptions);

            await query.ForEachAsync(sq =>
            {
                if (sq.SubmittedQuestions != null)
                {
                    foreach (var question in sq.SubmittedQuestions)
                    {
                        question.SubmittedQuiz = null;
                        if (question.SubmittedOptions != null)
                        {
                            foreach (var option in question.SubmittedOptions)
                            {
                                option.SubmittedQuestion = null;
                            }
                        }
                    }
                }
            });

            return await query.ToListAsync();
        }

        public async Task AddAsync(SubmittedQuiz submittedQuiz)
        {
            if (submittedQuiz == null)
                throw new ArgumentNullException(nameof(submittedQuiz));

            await _context.SubmittedQuizzes.AddAsync(submittedQuiz);
        }
    }
}