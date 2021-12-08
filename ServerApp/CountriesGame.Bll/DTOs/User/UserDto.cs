using System.Collections.Generic;

namespace CountriesGame.Bll.DTOs
{
    public class UserDto
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool PasswordConfirmed { get; set; }

        public string HeadId { get; set; } 

        public UserDto Head { get; set; }

        public IEnumerable<UserDto> SubUsers { get; set; }
    }
}