using System.ComponentModel.DataAnnotations;

namespace MyApp.Users.Dto
{
    public class LoginInput
    {
        public const int MaxPasswordLength = 256;

        [Required]
        [StringLength(User.MaxUsernameLength)]
        public string Username { get; set; }

        [Required]
        [StringLength(MaxPasswordLength)]
        public string Password { get; set; }
    }
}
