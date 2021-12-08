using System.ComponentModel.DataAnnotations;

namespace CountriesGame.Bll.DTOs
{
    public class AddUserDto
    {
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        public string HeadId { get; set; }
    }
}