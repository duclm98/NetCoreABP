using Microsoft.AspNetCore.Mvc;
using MyApp.Users;
using MyApp.Users.Dto;
using System.Threading.Tasks;

namespace MyApp.Web.Controllers
{
    [ApiController]
    [Route("app/users")]
    public class UserController : MyAppControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterInput input)
        {
            return Ok(await _userAppService.Register(input));
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginInput input)
        {
            return Ok(await _userAppService.Login(input));
        }
    }
}
