using Abp.Application.Services;
using MyApp.JsonWebToken.Dto;
using System.Collections.Generic;
using System.Security.Claims;

namespace MyApp.JsonWebToken
{
    public interface IJsonWebTokenAppService : IApplicationService
    {
        string CreateJsonWebToken(CreateJsonWebTokenInput input);
        IEnumerable<Claim> ValidateJsonWebToken(ValidateJsonWebTokenInput input);
    }
}
