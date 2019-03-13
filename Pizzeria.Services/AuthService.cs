using Microsoft.IdentityModel.Tokens;
using Pizzeria.Models.DTO;
using Pizzeria.Services.Contracts;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Pizzeria.Services
{
    public class AuthService : IAuthService
    {
        private readonly AuthParameters authParams;

        public AuthService(AuthParameters authParams)
        {
            if (authParams == null)
            {
                throw new ArgumentNullException("authParams");
            }

            this.authParams = authParams;
        }

        public string GenerateToken(UserDto user)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.authParams.Secret));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
                issuer: this.authParams.Issuer,
                audience: this.authParams.Issuer,
                claims: new List<Claim>()
                {
                        new Claim("Email", user.Email),
                        new Claim("FirstName", user.FirstName),
                        new Claim("Role", user.Role)
                },
                expires: DateTime.Now.AddMinutes(this.authParams.LifeTimeMinutes),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;
        }
    }
}
