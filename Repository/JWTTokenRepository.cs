using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using imc_web_api.Models;
using Microsoft.IdentityModel.Tokens;

namespace imc_web_api.Repository
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


            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            claims.Add(new Claim(ClaimTypes.Role, role));
           


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims ,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}