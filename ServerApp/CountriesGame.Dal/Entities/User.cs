using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace CountriesGame.Dal.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool PasswordConfirmed { get; set; }

        public string HeadId { get; set; } 

        public User Head { get; set; }

        public IEnumerable<User> SubUsers { get; set; }
    }
}