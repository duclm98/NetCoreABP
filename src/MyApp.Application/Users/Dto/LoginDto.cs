namespace MyApp.Users.Dto
{
    public class LoginDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
