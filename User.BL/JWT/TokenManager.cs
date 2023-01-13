using Main_Project.BL.DTO;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Main_Project.BL.JWT
{
    public class TokenManager
    {
        public static string CteateTokens(StudentDTO student)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, student.StudentID),
                new Claim(ClaimTypes.Email, student.Email),
                new Claim(ClaimTypes.MobilePhone, student.PhoneNumber),
                new Claim(ClaimTypes.Name, student.Fullname),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTconfig.KEY));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddDays(JWTconfig.LIFETIME);

            JwtSecurityToken token = new JwtSecurityToken
                (
                issuer: JWTconfig.ISSUER,
                audience: JWTconfig.AUDIENCE,
                claims: claims,
                expires: expiration,
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
