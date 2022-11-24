using Abp.Application.Services;
using Microsoft.IdentityModel.Tokens;
using MyApp.JsonWebToken.Dto;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyApp.JsonWebToken
{
    public class JsonWebTokenAppService : ApplicationService, IJsonWebTokenAppService
    {
        public string CreateJsonWebToken(CreateJsonWebTokenInput input)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(input.Secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                null,
                null,
                input.Claims,
                null,
                DateTime.Now.AddMinutes(input.Expires),
                credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public IEnumerable<Claim> ValidateJsonWebToken(ValidateJsonWebTokenInput input)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(input.Token, new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = input.ValidateLifetime, // validate thời gian hết hạn
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.ASCII.GetBytes(input.Secret)),
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out var validatedToken);
                var jwtToken = (JwtSecurityToken)validatedToken;

                return jwtToken.Claims;
            }
            catch
            {
                return new List<Claim>();
            }
        }
    }
}
