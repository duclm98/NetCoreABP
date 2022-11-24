using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp.Users
{
    [Table("AppUsers")]
    public class User : Entity, IHasCreationTime
    {
        public const int MaxUsernameLength = 256;
        public const int MaxPasswordLength = 64 * 1024;
        public const int MaxFullnameLength = 64 * 1024; // 64KB

        [Required]
        [StringLength(MaxUsernameLength)]
        public string Username { get; set; }

        [Required]
        [StringLength(MaxPasswordLength)]
        public string Password { get; set; }

        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        [StringLength(MaxFullnameLength)]
        public string Fullname { get; set; }

        public DateTime CreationTime { get; set; }

        public User()
        {
            CreationTime = Clock.Now;
        }

        public User(string username, string password, string fullname = null)
            : this()
        {
            Username = username;
            Password = password;
            Fullname = fullname;
        }
    }
}
