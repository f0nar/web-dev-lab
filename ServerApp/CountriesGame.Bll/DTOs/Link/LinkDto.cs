namespace CountriesGame.Bll.DTOs
{
    public class LinkDto
    {
        public string Id { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public string CountryId { get; set; }

        public CountryDto Country { get; set; }
    }
}