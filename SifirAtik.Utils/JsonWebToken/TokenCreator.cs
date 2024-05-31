using Microsoft.IdentityModel.Tokens;
using SifirAtik.Utils.AuthenticationKeys;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SifirAtik.Utils.JsonWebToken
{
    public class TokenCreator
    {
        public static string CreateToken(List<Claim> claims, string secretKey)
        {
            var key = KeyGenerator.GenerateSymmetricSecurityKey(secretKey);
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
