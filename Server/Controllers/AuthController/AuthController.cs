using System.Security.Claims;
using AutoMapper;
using imc_web_api.Dtos.AuthDtos;
using imc_web_api.Models;
using imc_web_api.Repository.AuthRepository;
using imc_web_api.Service.AuthService;
using imc_web_api.Service.AuthServices;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IQualificationService _qualificationService;
        private readonly IMapper _mapper;

        public AuthController(UserManager<user> manager, IJWTTokenRepository jWTTokenRepository, IRegistrationService registrationService, ILoginService loginService, IQualificationService qualificationService, IMapper mapper)
        {
            _userManager = manager;
            _jWTTokenRepository = jWTTokenRepository;
            _registrationService = registrationService;
            _loginService = loginService;
            _qualificationService = qualificationService;
            _mapper = mapper;
        }

        // Register
        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> Register(RegisterRequestDTO UserRegisterRequest)
        {
            try
            {
                var result = await _registrationService.AddUser(UserRegisterRequest);

                return Ok(new
                {
                    Message = "User Registerd Successfully!",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                // Log or print the exception details
                Console.WriteLine($"Exception: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }

                // Return a BadRequest response with the error details
                return BadRequest($"An error occurred. {ex.Message}. {ex.InnerException?.Message}");
            }

        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO UserLoginRequest)
        {
            try
            {
                var result = await _loginService.Login(UserLoginRequest);

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

        [HttpPost]
        [Route("AddQualification")]
        public async Task<IActionResult> AddQualification([FromBody] QualificationRequestDTO qualificationRequest)
        {
            var Qualification_Model = _mapper.Map<user_qualification>(qualificationRequest);
            var Qualification_Model_Result = await _qualificationService.AddQualification(Qualification_Model);
            var Qualification_Dto_Result = _mapper.Map<QualificationResponseDTO>(Qualification_Model_Result);
            return Ok(new
            {
                Data = Qualification_Dto_Result
            });
        }

        [HttpGet]
        [Route("GetQualifications")]
        public async Task<List<QualificationResponseDTO>> GetQualifications()
        {
            var Qualification_Model_Result = await _qualificationService.GetQualification();
            var Qualification_Dto_Result = _mapper.Map<List<QualificationResponseDTO>>(Qualification_Model_Result);
            return Qualification_Dto_Result;
        }

        [HttpGet]
        [Route("GetQualification/{id:Guid}")]
        public async Task<QualificationResponseDTO> GetQualification(Guid id)
        {
            var Qualification_Model_Result = await _qualificationService.GetQualificationById(id);

            var Qualification_DTO_Result = _mapper.Map<QualificationResponseDTO>(Qualification_Model_Result);
            return Qualification_DTO_Result;
        }

        [HttpDelete]
        [Route("DeleteQualification/{id:Guid}")]
        public async Task<QualificationResponseDTO> DeleteQualification(Guid id)
        {
            var Qualification_Model_Result = await _qualificationService.DeleteQualificationById(id);

            var Qualification_DTO_Result = _mapper.Map<QualificationResponseDTO>(Qualification_Model_Result);
            return Qualification_DTO_Result;
        }

        [HttpPut]
        [Route("UpdateQualification/{id:Guid}")]
        public async Task<IActionResult> UpdateQualification(Guid id, [FromBody] QualificationRequestDTO qualificationRequest)
        {
            var Qualification_Model = _mapper.Map<user_qualification>(qualificationRequest);
            var Qualification_Model_Result = await _qualificationService.UpdateQualification(id, Qualification_Model);
            var Qualification_Dto_Result = _mapper.Map<QualificationResponseDTO>(Qualification_Model_Result);
            return Ok(new
            {
                Data = Qualification_Dto_Result
            });
        }


        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        [Route("check_my_status")]
        [Authorize(Roles ="Admin")]
        public  async Task<String> checkMyAuthentication()
        {
            //how to get userId from token
            var token = HttpContext.Request.Headers["Authorization"];

            // Get the UserId from the token
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

         return $"Current User Id :  {userId}";
        }
    }
}