using System.Collections.Generic;

namespace CountriesGame.Dal.Entities
{
    public class Quiz : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public IEnumerable<Question> Questions { get; set; }
    }
}