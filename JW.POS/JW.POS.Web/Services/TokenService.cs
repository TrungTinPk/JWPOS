using JW.POS.User.Models;
using Light.GuardClauses;
using Microsoft.Extensions.Options;
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
        private readonly TokenSetting _tokenSetting;
        public TokenService(IOptions<TokenSetting> tokenOptions)
        {
            _tokenSetting = tokenOptions.Value;

            _tokenSetting.SecurityKey.MustNotBeNullOrEmpty();
            _tokenSetting.Issuer.MustNotBeNullOrEmpty();
            _tokenSetting.Audience.MustNotBeNullOrEmpty();
        }

        public string GetToken(UserToken user, int expiryMinutes = 0)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Role, user.Role)
            };

            if (expiryMinutes == 0)
            {
                expiryMinutes = _tokenSetting.ExpiryMinutes;
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSetting.SecurityKey));
            var token = new JwtSecurityToken(
                issuer: _tokenSetting.Issuer,
                audience: _tokenSetting.Audience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(expiryMinutes),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
