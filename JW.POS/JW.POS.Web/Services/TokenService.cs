using JW.POS.User.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JW.POS.Web.Services
{
    public interface ITokenService
    {
        string GetToken(UserToken user, int expiryMinutes = 0);
    }
    public class TokenService : ITokenService
    {
        public string GetToken(UserToken user, int expiryMinutes = 0)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(""));
            var token = new JwtSecurityToken(
                issuer: "",
                audience: "",
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(expiryMinutes),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
