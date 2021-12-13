using System.Collections.Generic;

namespace CountriesGame.Dal.Entities
{
    public class Country : BaseEntity
    {
        public string CountryName { get; set; }

        public string CapitalName { get; set; }

        public string FlagPath { get; set; }

        public string CoatPath { get; set; }

        public string AnthemPath { get; set; }

        public IEnumerable<Link> Links { get; set; }
    }
}