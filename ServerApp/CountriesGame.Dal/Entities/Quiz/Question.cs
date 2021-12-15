using System.Collections.Generic;

namespace CountriesGame.Dal.Entities
{
    public class Question : BaseEntity
    {
        public string Content { get; set; }

        public QuestionType Type { get; set; }

        public string QuizId { get; set; }

        public Quiz Quiz { get; set; }

        public IEnumerable<Option> Options { get; set; }
    }
}