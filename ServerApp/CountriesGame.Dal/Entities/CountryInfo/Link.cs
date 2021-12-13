namespace CountriesGame.Dal.Entities
{
    public class Link : BaseEntity
    {
        public string Url { get; set; }

        public string Description { get; set; }

        public string CountryId { get; set; }

        public Country Country { get; set; }
    }
}