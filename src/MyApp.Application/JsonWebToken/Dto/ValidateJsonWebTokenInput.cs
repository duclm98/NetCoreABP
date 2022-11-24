using System.ComponentModel.DataAnnotations;

namespace MyApp.JsonWebToken.Dto
{
    public class ValidateJsonWebTokenInput
    {
        [Required]
        public string Token { get; set; }

        public bool ValidateLifetime { get; set; } = true;

        [Required]
        public string Secret { get; set; }

        [Required]
        public int Expires { get; set; } // Minute
    }
}
