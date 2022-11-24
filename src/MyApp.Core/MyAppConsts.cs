namespace MyApp
{
    public class MyAppConsts
    {
        public const string LocalizationSourceName = "MyApp";

        public const string ConnectionStringName = "Default";

        public const string AccessTokenSecret = "Jwt:AccessTokenSecret";
        public const string AccessTokenExpires = "Jwt:AccessTokenExpires";
        public const string RefreshTokenSecret = "Jwt:RefreshTokenSecret";
        public const string RefreshTokenExpires = "Jwt:RefreshTokenExpires";

        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public const string DefaultPassPhrase = "c11f13592c5b4828ace6258d0b138437";
    }
}