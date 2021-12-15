using System.Collections.Generic;

namespace CountriesGame.Dal.Entities
{
    public class SubmittedQuestion : BaseEntity
    {
        public string QuestionId { get; set; }

        public Question Question { get; set; }

        public string SubmittedQuizId { get; set; }

        public SubmittedQuiz SubmittedQuiz { get; set; }

        public IEnumerable<SubmittedOption> SubmittedOptions { get; set; }
    }
}