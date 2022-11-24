using Abp.Application.Services;
using Abp.Domain.Repositories;
using MyApp.Configuration;
using MyApp.Exceptions;
using MyApp.JsonWebToken;
using MyApp.JsonWebToken.Dto;
using MyApp.Users.Dto;
using MyApp.Web;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyApp.Users
{
    public class UserAppService : ApplicationService, IUserAppService
    {
        private readonly IJsonWebTokenAppService _jsonWebTokenAppService;
        private readonly IRepository<User> _userRepository;

        public UserAppService(IJsonWebTokenAppService jsonWebTokenAppService,
            IRepository<User> userRepository)
        {
            _jsonWebTokenAppService = jsonWebTokenAppService;
            _userRepository = userRepository;
        }

        public async Task<RegisterDto> Register(RegisterInput input)
        {
            var user = await _userRepository.FirstOrDefaultAsync(t => t.Username == input.Username);
            if (user != null)
                throw new CustomException("Tên đăng nhập đã tồn tại", 400);

            var hashedPassword = HashPassword(input.Password);
            var newUser = new User(input.Username, hashedPassword, input.Fullname);
            await _userRepository.InsertAsync(newUser);
            return ObjectMapper.Map<RegisterDto>(newUser);
        }

        public async Task<LoginDto> Login(LoginInput input)
        {
            var user = await _userRepository.FirstOrDefaultAsync(t => t.Username == input.Username);
            if (user == null)
                throw new CustomException("Tên tài khoản hoặc mật khẩu không chính xác", 409);

            var isMatch = BCrypt.Net.BCrypt.Verify(input.Password, user.Password);
            if (!isMatch)
                throw new CustomException("Tên tài khoản hoặc mật khẩu không chính xác", 409);

            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            var accessToken = _jsonWebTokenAppService.CreateJsonWebToken(new CreateJsonWebTokenInput
            {
                Claims = new[]
                {
                    new Claim("UserId", user.Id.ToString())
                },
                Secret = configuration[MyAppConsts.AccessTokenSecret],
                Expires = int.Parse(configuration[MyAppConsts.AccessTokenExpires])
            });
            user.AccessToken = accessToken;

            var refreshToken = _jsonWebTokenAppService.CreateJsonWebToken(new CreateJsonWebTokenInput
            {
                Claims = new[]
                {
                    new Claim("UserId", user.Id.ToString())
                },
                Secret = configuration[MyAppConsts.RefreshTokenSecret],
                Expires = int.Parse(configuration[MyAppConsts.RefreshTokenExpires])
            });
            user.RefreshToken = refreshToken;

            await _userRepository.UpdateAsync(user);

            return ObjectMapper.Map<LoginDto>(user);
        }

        private static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, 5);
        }
    }
}
