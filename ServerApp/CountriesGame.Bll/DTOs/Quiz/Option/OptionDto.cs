namespace CountriesGame.Bll.DTOs
{
    public class OptionDto
    {
        public string Id { get; set; }

        public string Content { get; set; }

        public string MatchContent { get; set; }

        public string QuestionId { get; set; }

        public QuestionDto Question { get; set; }
    }
}