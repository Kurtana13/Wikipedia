using System.ComponentModel.DataAnnotations;

namespace Wikipedia.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Please enter your Name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please enter your User Name")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Please enter your Email")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Please re-enter your Password")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "Password and confirmation password do not match")]
        public string? ConfirmPassword { get; set; }
    }
}
