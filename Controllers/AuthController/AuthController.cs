using imc_web_api.Dtos;
using imc_web_api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace imc_web_api.Controllers.AuthController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<user> _userManager;

        public AuthController(UserManager<user> manager)
        {
            _userManager = manager;
        }

        // Register
        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> Register(RegisterationDTO register)
        {
            if (register == null)
            {
                return BadRequest(ModelState);
            }

            //user object
            var user = new user
            {
                firstName = register.firstName,
                lastName = register.lastName,
                Email = register.Email,
                UserName = register.Email,
                contact = register.contact,
                gender = register.gender,
                Role = register.Role,
            };
            // check the User is Already Exist
            var isExistingUser = await _userManager.FindByEmailAsync(register.Email) != null;

            if (isExistingUser)
            {
                return BadRequest("User already exists.");
            }

            var registerdUser = await _userManager.CreateAsync(user, register.password);

            if (!registerdUser.Succeeded)
            {
                return BadRequest("Failed to register user.");
            }
            if (!string.IsNullOrWhiteSpace(register.Role))
            {
                //Add Role For the user
                registerdUser = await _userManager.AddToRoleAsync(user, register.Role);

                if (registerdUser.Succeeded)
                {
                    return Ok("User registered successfully!");
                }
                else
                {
                    // Rollback user creation if adding role fails
                    await _userManager.DeleteAsync(user);
                    return BadRequest("Failed to assign role to user.");
                }
            }
            return Ok("User registered successfully!");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO logindto)
        {
            var user = await _userManager.FindByEmailAsync(logindto.Email);

            if (user != null)
            {
                // Check if the provided password is valid
                var result = await _userManager.CheckPasswordAsync(user, logindto.Password);

                if (result)
                {
                    // If password is valid, retrieve user roles
                    var roles = await _userManager.GetRolesAsync(user);

                    if (roles != null)
                    {
                        // Create a JWT token for the authenticated user
                        //var jwtToken = _tokenrepository.CreateJWTToken(user, roles.ToList());

                        // Build the response with the JWT token
                        var response = new LoginResponseDTO
                        {
                            JwtToken = "jwtToken"
                        };
                        return Ok(response);  // Return successful response with JWT token
                    }
                }
            }

            // Log the failed login attempt for security monitoring

            return BadRequest("Invalid Credential");  // Return bad request for invalid credentials
        }
    }
}