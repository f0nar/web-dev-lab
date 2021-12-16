using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CountriesGame.Bll.DTOs;
using CountriesGame.Bll.Services.Interfaces;
using CountriesGame.Dal.Entities;
using CountriesGame.Dal.UnitOfWorks.Interfaces;

namespace CountriesGame.Bll.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly IUnitOfWork _db;

        private readonly IQuizService _quizService;

        private readonly IMapper _mapper;

        public StatisticService(IUnitOfWork unitOfWork, IQuizService quizService,
            IMapper mapper)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));
            if (quizService == null)
                throw new ArgumentNullException(nameof(quizService));
            if (mapper == null)
                throw new ArgumentNullException(nameof(mapper));

            _db = unitOfWork;
            _quizService = quizService;
            _mapper = mapper;
        }

        public async Task<StatisticDto> GetStatisticByHeadId(string quizId, string headId)
        {
            if (headId == null)
                throw new ArgumentNullException(nameof(headId));

            var users = await _db.Users.GetByHeadIdAsync(headId);
            var submittedQuizzes = await _db.SubmittedQuizzes.GetByQuizIdAsync(quizId);
            var quiz = await _db.Quizzes.GetAsync(quizId);
            var quizDto = _mapper.Map<QuizDto>(quiz);

            var testResults = submittedQuizzes
                .Join(users,
                    sq => sq.UserId,
                    u => u.Id,
                    (sq, u) => new { SubmittedQuiz = sq, User = u })
                .Select(async obj => new TestResultDto
                {
                    User = _mapper.Map<UserDto>(obj.User),
                    Grade = await _quizService.GetQuizResultAsync(
                        _mapper.Map<NewSubmittedQuizDto>(obj.SubmittedQuiz), obj.User.Id)
                })
                .Select(tr => tr.Result);
                
            return new StatisticDto
            {
                AvarageGrade = GetAvarageGrade(submittedQuizzes),
                SubmittedCount = submittedQuizzes.Count(),
                ExpectedSubmittedCount = users.Count(),
                Quiz = quizDto,
                TestResults = testResults
            };
        }

        private double GetAvarageGrade(IEnumerable<SubmittedQuiz> submittedQuizzes)
        {
            if (!submittedQuizzes.Any())
                return 0.0;
            var avarageGrade = submittedQuizzes
                .Select(async sq =>
                {
                    var sqDto = _mapper.Map<NewSubmittedQuizDto>(sq);
                    return await _quizService.GetQuizResultAsync(sqDto, sq.UserId);
                })
                .Average(d => d.Result);

            return avarageGrade;
        }
    }
}