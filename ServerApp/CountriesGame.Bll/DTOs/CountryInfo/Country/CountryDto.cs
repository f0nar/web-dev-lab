using System.Collections.Generic;

namespace CountriesGame.Bll.DTOs
{
    public class CountryDto
    {
        public string Id { get; set; }

        public string CountryName { get; set; }

        public string CapitalName { get; set; }

        public IEnumerable<LinkDto> Links { get; set; }
    }
}