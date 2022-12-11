using System.Text;
using Tryitter.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Tryitter.Auth;
using Auth.Models;

namespace Tryitter.Services
{
    public class TokenGenerator
    {
        public string Generate(Login login)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = AddClaims(login),
                SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.ASCII.GetBytes(TokenConstants.Secret)),
                        SecurityAlgorithms.HmacSha256Signature
                    ),
                Expires = DateTime.Now.AddDays(1)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        
        private ClaimsIdentity AddClaims(Login login)
        {
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim("Tryitter", "Student"));
            return claims;
        }
    }
}