using imc_web_api.Dtos.AuthDtos;
using imc_web_api.Models;
using imc_web_api.Repository;
using imc_web_api.Repository.AuthRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace imc_web_api.Service.AuthService
{
    public class LoginService : ILoginService
    {

        private readonly UserManager<user> _userManager;
        private readonly IJWTTokenRepository _jwtTokenRepository;
        public LoginService(UserManager<user> userManager ,IJWTTokenRepository jWTTokenRepository )
        {
            _userManager = userManager;
            _jwtTokenRepository = jWTTokenRepository;
        }

        // Login 
        public async Task<LoginResponseDTO> Login(LoginRequestDTO userData)
        {
            var user = await _userManager.FindByEmailAsync(userData.Email);

            if (user != null)
            {
                // Check if the provided password is valid
                var result = await _userManager.CheckPasswordAsync(user, userData.Password);

                if (result)
                {
                    // If password is valid, retrieve user roles
                    var role = await _userManager.GetRolesAsync(user);

                    if (role != null && role.Any())
                    {
                        // Create a JWT token for the authenticated user
                        var jwtToken = _jwtTokenRepository.CreateJWTToken(user, role.ToString());

                        // Build the response with the JWT token
                        var response = new LoginResponseDTO
                        {
                            JwtToken = jwtToken,
                            FirstName =  user.FirstName,
                            LastName =  user.LastName,
                            Email = user.Email,
                            Role = user.Role,
                        };
                        return response; 
                    }
                    else
                    {
                         throw new  Exception("Something went Wrong!");
                    }
                }
            }
                throw new Exception("Invalid email or password.");
        }
    }
}
