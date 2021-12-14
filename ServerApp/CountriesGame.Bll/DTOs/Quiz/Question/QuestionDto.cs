using System.Collections.Generic;

namespace CountriesGame.Bll.DTOs
{
    public class QuestionDto
    {
        public string Id { get; set; }

        public string Content { get; set; }

        public QuestionTypeDto Type { get; set; }

        public string QuizId { get; set; }

        public QuizDto Quiz { get; set; }

        public IEnumerable<OptionDto> Options { get; set; }
    }
}