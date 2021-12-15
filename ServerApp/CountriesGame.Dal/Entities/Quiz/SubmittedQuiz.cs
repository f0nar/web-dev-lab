using System.Collections.Generic;

namespace CountriesGame.Dal.Entities
{
    public class SubmittedQuiz : BaseEntity
    {
        public string QuizId { get; set; }

        public Quiz Quiz { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public IEnumerable<SubmittedQuestion> SubmittedQuestions { get; set; }
    }
}