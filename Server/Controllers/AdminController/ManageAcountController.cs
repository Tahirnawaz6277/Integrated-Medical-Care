using AutoMapper;

using imc_web_api.Dtos.AuthDtos;
using imc_web_api.Models;
using imc_web_api.Service.AdminServices.ManageAccountServices;
using Microsoft.AspNetCore.Authorization;
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

        public ManageAcountController(UserManager<user> userManager, IManageAccountService manageAccountService , IMapper mapper)
        {
            _userManager = userManager;
            _manageAccountService = manageAccountService;
           _mapper = mapper;
        }

        //--> Create User

        [HttpPost]
        [Route("CreateUser")]
        //[Authorize(Roles = "Admin,Customer")]
        public async Task<user> CreateUser([FromBody] RegisterRequestDTO UserInputReguest)
        {
            return await _manageAccountService.AddUser(UserInputReguest);
        }

        //--> Get Users
        //[Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _manageAccountService.GetUsers();
            var Dto_Result = _mapper.Map<List<RegisterationResponseDto>>(result);
            return Ok(new
            {
                success = true,
                data = Dto_Result
            }) ;
        }

        //--> Get User By Id
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("GetUserById/{id:Guid}")]
        public async Task<user> GetUserById(Guid id)
        {
            return await _manageAccountService.GetUserById(id);
        }

        //--> Update User
        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("UpdateUser /{id:Guid}")]
        public async Task<user> UpdateUser(Guid id, [FromBody] RegisterRequestDTO UserInputRequest)
        {
            return await _manageAccountService.UpdateUser(id, UserInputRequest);
        }

        //--> Delete User
        //[Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("DeleteUser/{id:Guid}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            

            var result =  await _manageAccountService.DeleteUser(id);

            return Ok(new
            {
                success = true,
                data = result
            });

        }
    }
}