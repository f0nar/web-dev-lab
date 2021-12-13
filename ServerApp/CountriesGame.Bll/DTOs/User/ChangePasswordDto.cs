using System.ComponentModel.DataAnnotations;

namespace CountriesGame.Bll.DTOs
{
    public class ChangePasswordDto
    {
        [Required]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Password mismatch")]
        public string NewPasswordConfirm { get; set; }
    }
}