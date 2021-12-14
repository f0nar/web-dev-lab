using System.Collections.Generic;

namespace CountriesGame.Bll.DTOs
{
    public class NewSubmittedQuestionDto
    {
        public string QuestionId { get; set; }

        public IEnumerable<NewSubmittedOptionDto> SubmittedOptions { get; set; }
    }
}