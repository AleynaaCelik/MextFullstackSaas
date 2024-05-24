using MextFullstackSaas.Domain.Identity;
using MextFullstackSaas.Domain.Settings;
using MextFullStackSaas.Application.Common.Interfaces;
using MextFullStackSaas.Application.Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Infrastructure.Services
{
    public class JwtManager:IJwtService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly UserManager<User> _userManager;


        public JwtManager(IOptions<JwtSettings>jwtSettingsOptions,UserManager<User> userManager)
        {
            _userManager = userManager;      _jwtSettings=jwtSettingsOptions.Value;

        }

        public JwtDto GenareteToken(User user, List<string> roles)
        {
            throw new NotImplementedException();
        }

        public   Task<JwtDto> GenerateTokenAsync(Guid userId, string email, CancellationToken cancellationToken)
        {
            var expirationTime = DateTime.Now.AddMinutes(_jwtSettings.AccessTokenExpirationInMinutes);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email,email),
                new Claim("uid",userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iss,_jwtSettings.Issuer),
                new Claim(JwtRegisteredClaimNames.Aud,_jwtSettings.Audience),
                new Claim(JwtRegisteredClaimNames.Iat,DateTime.Now.ToFileTimeUtc().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp,expirationTime.ToFileTimeUtc().ToString()),

            };
            //We've cerated the security key using the secret key from the appsetings.json 
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var jwtToken = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                expires: expirationTime,
                signingCredentials: credentials
                );
            var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return Task.FromResult(new JwtDto(token,expirationTime));
        }
    }
}
