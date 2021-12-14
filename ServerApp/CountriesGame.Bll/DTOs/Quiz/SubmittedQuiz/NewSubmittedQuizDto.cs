using System.Collections.Generic;

namespace CountriesGame.Bll.DTOs
{
    public class NewSubmittedQuizDto
    {
        public string QuizId { get; set; }

        public IEnumerable<NewSubmittedQuestionDto> SubmittedQuestions { get; set; }
    }
}