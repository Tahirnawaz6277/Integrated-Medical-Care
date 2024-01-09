using imc_web_api.Dtos.AuthDtos;
using imc_web_api.Models;
using imc_web_api.Repository.AuthRepository;
using imc_web_api.Service.AuthService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace imc_web_api.Controllers.AuthController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<user> _userManager;

        private readonly IJWTTokenRepository _jWTTokenRepository;
        private readonly IRegistrationService _registrationService;
        private readonly ILoginService _loginService;

        public AuthController(UserManager<user> manager, IJWTTokenRepository jWTTokenRepository, IRegistrationService registrationService, ILoginService loginService)
        {
            _userManager = manager;
            _jWTTokenRepository = jWTTokenRepository;
            _registrationService = registrationService;
            _loginService = loginService;
        }

        // Register
        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> Register(RegisterRequestDTO userData)
        {
            try
            {
                var result = await _registrationService.AddUser(userData);

                return Ok(new
                {
                    Message = "User Registerd Successfully!",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO UserData)
        {
            try
            {
                var result = await _loginService.Login(UserData);

                return Ok(new
                {
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}