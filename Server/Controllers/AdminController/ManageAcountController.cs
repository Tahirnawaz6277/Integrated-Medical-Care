using AutoMapper;

using imc_web_api.Dtos.AuthDtos;
using imc_web_api.Models;
using imc_web_api.Service.AdminServices.ManageAccountServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace imc_web_api.Controllers.AdminController
{
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class ManageAcountController : ControllerBase
    {
        private readonly UserManager<user> _userManager;
        private readonly IManageAccountService _manageAccountService;
        private readonly IMapper _mapper;

        public ManageAcountController(UserManager<user> userManager, IManageAccountService manageAccountService, IMapper mapper)
        {
            _userManager = userManager;
            _manageAccountService = manageAccountService;
            _mapper = mapper;
        }

        //--> Create User

        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] RegisterRequestDTO UserInputReguest)
        {
            try
            {
                var result = await _manageAccountService.AddUser(UserInputReguest);
                return Ok(new
                {
                    Success = true,
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    ExrrorMessage = ex.Message
                });
            }
        }

        //--> Get Users
        //[Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var result = await _manageAccountService.GetUsers();
                var Dto_Result = _mapper.Map<List<RegisterationResponseDto>>(result);

                return Ok(new
                {
                    Success = true,
                    Data = Dto_Result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    ErrorMessage = ex.Message
                });
            }
        }

        //--> Get User By Id
        //[Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("GetUserById/{id:Guid}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest("Id Field is Required!");
                }
                var result = await _manageAccountService.GetUserById(id);
                return Ok(new
                {
                    Success = true,
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    ErrorMessage = ex.Message
                });
            }
        }

        //--> Update User
        //[Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("UpdateUser /{id:Guid}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] RegisterRequestDTO UserInputRequest)
        {
            try
            {
                if (id == Guid.Empty || UserInputRequest == null)
                {
                    return BadRequest("Input Field is Required!");
                }

                var result = await _manageAccountService.UpdateUser(id, UserInputRequest);

                if (result == null)
                {
                    return NotFound("Record Not Found!");
                }

                return Ok(new
                {
                    Success = true,
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    ErrorMessage = ex.Message
                });
            }
        }

        //--> Delete User
        //[Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("DeleteUser/{id:Guid}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest("Id Field is Required!");
                }

                var result = await _manageAccountService.DeleteUser(id);

                if (result == null)
                {
                    return NotFound("Record Not Found!");
                }

                return Ok(new
                {
                    Success = true,
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    ErrorMessage = ex.InnerException.Message
                });
            }
        }
    }
}