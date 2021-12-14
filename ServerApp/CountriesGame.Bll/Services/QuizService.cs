using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CountriesGame.Bll.DTOs;
using CountriesGame.Bll.Exceptions;
using CountriesGame.Bll.Extentions;
using CountriesGame.Dal.Entities;
using CountriesGame.Dal.FileReaders.Interfaces;
using CountriesGame.Dal.UnitOfWorks.Interfaces;

namespace CountriesGame.Bll.Services.Interfaces
{
    public class QuizService : IQuizService
    {
        private readonly IUnitOfWork _db;

        private readonly IFileReader _reader;

        private readonly IMapper _mapper;

        public QuizService(IUnitOfWork unitOfWork, IFileReader fileReader,
            IMapper mapper)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));
            if (fileReader == null)
                throw new ArgumentNullException(nameof(fileReader));
            if (mapper == null)
                throw new ArgumentNullException(nameof(mapper));

            _db = unitOfWork;
            _reader = fileReader;
            _mapper = mapper;
        }

        public async Task<QuizDto> GetQuizAsync(string id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            var quiz = await _db.Quizzes.GetAsync(id);
            if (quiz == null)
                return null;

            var quizDto = _mapper.Map<QuizDto>(quiz);

            foreach (var question in quizDto.Questions)
            {
                if (question != null && question.Type == QuestionTypeDto.FindMatches)
                {
                    var matchContents = question.Options
                        .Select(o => o.MatchContent)
                        .Shuffle()
                        .ToList();

                    int counter = 0;
                    foreach (var option in question.Options)
                    {
                        option.MatchContent = matchContents[counter];
                        counter++;
                    }
                }
            }

            return quizDto;
        }

        public async Task<IEnumerable<QuizDto>> GetQuizzesAsync()
        {
            var quizzes = await _db.Quizzes.GetAllAsync();
            var quizDtos = _mapper.Map<IEnumerable<QuizDto>>(quizzes);

            return quizDtos;
        }

        public async Task<int> GetQuizResultAsync(NewSubmittedQuizDto submittedQuiz, string userId)
        {
            if (submittedQuiz == null)
                throw new ArgumentNullException(nameof(submittedQuiz));
            if (userId == null)
                throw new ArgumentNullException(nameof(userId));

            int totalScore = 0;

            foreach (var sQuestion in submittedQuiz.SubmittedQuestions)
            {
                var question = await _db.Questions.GetAsync(sQuestion.QuestionId);
                if (question == null)
                    throw new EntityNotFoundException("Question with specified id is not found");

                var questionScore = 0;
                if (question.Type != QuestionType.FindMatches)
                {
                    foreach (var sOption in sQuestion.SubmittedOptions)
                    {
                        var option = await _db.Options.GetAsync(sOption.OptionId);
                        if (option == null)
                            throw new EntityNotFoundException("Option with specified id is not found");

                        if (!option.IsCorrect.Value)
                            questionScore--;
                        questionScore++;
                    }
                }
                else
                {
                    foreach (var sOption in sQuestion.SubmittedOptions)
                    {
                        var option = await _db.Options.GetAsync(sOption.OptionId);
                        if (option == null)
                            throw new EntityNotFoundException("Option with specified id is not found");
                        if (option.MatchContent == sOption.MatchContent)
                            questionScore++;
                    }
                }
                totalScore += questionScore < 0 ? 0 : questionScore;
            }

            return totalScore;
        }
    }
}