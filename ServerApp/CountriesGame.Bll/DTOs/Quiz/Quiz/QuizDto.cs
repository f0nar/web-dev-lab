using System.Collections.Generic;

namespace CountriesGame.Bll.DTOs
{
    public class QuizDto
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IEnumerable<QuestionDto> Questions { get; set; }
    }
}