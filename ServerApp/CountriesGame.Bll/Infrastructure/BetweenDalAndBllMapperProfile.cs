using AutoMapper;
using CountriesGame.Bll.DTOs;
using CountriesGame.Dal.Entities;

namespace CountriesGame.Bll.Infrastructure
{
    public class BetweenDalAndBllMapperProfile : Profile
    {
        public BetweenDalAndBllMapperProfile()
        {
            CreateCountryMap();
            CreateLinkMap();
            CreateUserMap();

            CreateQuizMap();
            CreateQuestionMap();
            CreateOptionMap();
            CreateSubmittedQuizMap();
            CreateSubmittedQuestionMap();
            CreateSubmittedOptionMap();
        }

        private void CreateCountryMap()
        {
            CreateMap<Country, CountryDto>();
        }

        private void CreateLinkMap()
        {
            CreateMap<Link, LinkDto>();
        }

        private void CreateUserMap()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<LoginDto, User>();
            CreateMap<RegisterDto, User>();
            CreateMap<ChangePasswordDto, User>();
        }

        private void CreateQuizMap()
        {
            CreateMap<Quiz, QuizDto>();
        }

        private void CreateQuestionMap()
        {
            CreateMap<Question, QuestionDto>();
            CreateMap<QuestionType, QuestionTypeDto>();
        }

        private void CreateOptionMap()
        {
            CreateMap<Option, OptionDto>();
        }

        private void CreateSubmittedQuizMap()
        {
            CreateMap<SubmittedQuiz, NewSubmittedQuizDto>().ReverseMap();
        }

        private void CreateSubmittedQuestionMap()
        {
            CreateMap<SubmittedQuestion, NewSubmittedQuestionDto>().ReverseMap();
        }

        private void CreateSubmittedOptionMap()
        {
            CreateMap<SubmittedOption, NewSubmittedOptionDto>().ReverseMap();
        }
    }
}