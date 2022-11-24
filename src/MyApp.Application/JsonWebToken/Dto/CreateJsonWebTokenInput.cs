using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace MyApp.JsonWebToken.Dto
{
    public class CreateJsonWebTokenInput
    {
        [Required]
        public IEnumerable<Claim> Claims { get; set; }

        [Required]
        public string Secret { get; set; }

        [Required]
        public int Expires { get; set; } // Minute
    }
}
