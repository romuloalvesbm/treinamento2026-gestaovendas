using GestaoVendas.API.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GestaoVendas.API.Helpers
{
    public class JwtTokenHelper(IOptions<JwtTokenSettings> jwtTokenSettings)
    {
        private readonly JwtTokenSettings _settings = jwtTokenSettings.Value;

        public string GenerateToken(string nome, string email)
        {
            var secretKey = _settings.SecretKey;

            if (string.IsNullOrEmpty(secretKey))
                throw new Exception("Secret key not configured.");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(_settings.ExpirationInHours);

            var token = CreateJwtToken(
                 CreateClaims(nome, email),
                 credentials,
                expiration
             );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        private JwtSecurityToken CreateJwtToken(List<Claim> claims, SigningCredentials credentials, DateTime expiration) =>
            new(
                _settings.Issuer,
                _settings.Audience,
                claims,
                expires: expiration,
                signingCredentials: credentials
            );

        private List<Claim> CreateClaims(string nome, string email)
        {
            var jwtSub = _settings.JwtClaimNamesSub;

            var claims = new List<Claim>
            {
                new (JwtRegisteredClaimNames.Sub, jwtSub),
                new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new (JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()),
                new (ClaimTypes.Name, nome),
                new (ClaimTypes.Email, email),
            };

            //permissoes
            string[] permissoes = ["GetAll"];

            foreach (var item in permissoes)
            {
                claims.Add(new Claim("CustomizePermission", item));
            }

            return claims;
                    
        }
    }
}
