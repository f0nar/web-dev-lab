using System.ComponentModel.DataAnnotations;

namespace CountriesGame.Bll.DTOs
{
    public class LoginDto
    {
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}