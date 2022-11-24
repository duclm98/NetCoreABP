using Abp.Application.Services;
using MyApp.Users.Dto;
using System.Threading.Tasks;

namespace MyApp.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task<RegisterDto> Register(RegisterInput input);
        Task<LoginDto> Login(LoginInput input);
    }
}
