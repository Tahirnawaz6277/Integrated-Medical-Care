using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using imc_web_api.Models;
using Microsoft.IdentityModel.Tokens;

namespace imc_web_api.Repository.AuthRepository
{
    public class JWTTokenRepository : IJWTTokenRepository
    {
        private readonly IConfiguration _configuration;

        public JWTTokenRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateJWTToken(user user, string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {                      

          new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role,user.Role)
            };
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(1440),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);

            
        }
    }
}