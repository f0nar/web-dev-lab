namespace CountriesGame.Dal.Entities
{
    public class SubmittedOption : BaseEntity
    {
        public string MatchContent { get; set; }

        public string OptionId { get; set; }

        public Option Option { get; set; }
        
        public string SubmittedQuestionId { get; set; }

        public SubmittedQuestion SubmittedQuestion { get; set;}
    }
}