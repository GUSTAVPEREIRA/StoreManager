using System;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using StoreManager.Core.Domain;
using StoreManager.Core.Auth.Interfaces;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;

namespace StoreManager.Application.Auth.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration configuration;

        public JwtService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration.GetSection("JWT:Secret").Value);

            List<Claim> claims = GenerateClaims(user);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Audience = configuration.GetSection("JWT:Audience").Value,
                Issuer = configuration.GetSection("JWT:Issuer").Value,
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(configuration.GetSection("JWT:ExpireMinutsTime").Value)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private static List<Claim> GenerateClaims(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Login)
            };

            foreach (var function in user.Functions)
            {
                claims.Add(new Claim("FunctionDescription", function.Description));

                if (function.Admin)
                {
                    claims.Add(new Claim(ClaimTypes.Role, nameof(function.Admin)));
                }
            }

            return claims;
        }
    }
}