using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using OZ_ETicaret.Application.Abstracts.Services;
using OZ_ETicaret.Application.DTOs;
using OZ_ETicaret.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Infrastructure.Concretes.Services
{
    public class TokenService(IConfiguration configuration) : ITokenService
    {

        public TokenDTO CreateToken(int minutes, AppUser user, IList<string> roles)
        {
            TokenDTO token = new() { ExpiringDate = DateTime.UtcNow.AddMinutes(minutes), RefreshToken = CreateRefreshToken() };

            SecurityKey secKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTToken:SigningKey"]));
            SigningCredentials signingCredentials = new(secKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim> { new(ClaimTypes.Name,user.UserName)};
            claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

            JwtSecurityToken securityToken = new(
                audience: configuration["JWTToken:Audience"],
                issuer: configuration["JWTToken:Issuer"],
                notBefore: DateTime.UtcNow,
                expires: token.ExpiringDate,
                signingCredentials: signingCredentials,
                claims: claims
                );

            JwtSecurityTokenHandler tokenHandler = new();
            token.Token = tokenHandler.WriteToken(securityToken);
            return token;
        }
        public string CreateRefreshToken()
        {
            byte[] bytes = new byte[32];
            RandomNumberGenerator.Create().GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }

    }
}
