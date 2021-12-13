namespace CountriesGame.Dal.Entities
{
    public class Option : BaseEntity
    {
        public string Content { get; set; }

        public bool? IsCorrect { get; set; }

        public string MatchContent { get; set; }

        public string QuestionId { get; set; }

        public Question Question { get; set; }
    }
}