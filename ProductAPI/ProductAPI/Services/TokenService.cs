using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProductAPI.Models;
using ProductAPI.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductAPI.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetToken(User user)
        {
            // Token generator
            var tokenHandler = new JwtSecurityTokenHandler();

            // Get our secret key from appSettings and convert to a bytes array 
            var secretKey = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("SecretJWT"));

            var propertiesToken = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, (user.SystemRole).ToString())
                }),

                // Expiration time(8 hours)
                Expires = DateTime.UtcNow.AddHours(8),

                // Add our secret key to encription
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(secretKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            // Create our token and returns it
            var token = tokenHandler.CreateToken(propertiesToken);
            return tokenHandler.WriteToken(token);
        }
    }
}
