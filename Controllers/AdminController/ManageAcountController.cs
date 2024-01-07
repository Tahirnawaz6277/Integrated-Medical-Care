using imc_web_api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace imc_web_api.Controllers.AdminController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageAcountController : ControllerBase
    {
        private readonly UserManager<user> _userManager;

        public ManageAcountController(UserManager<user> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser()
        {
            return null;
        }

        [HttpGet]
        [Route("GetUsers")]
        public async Task<List<user>> GetUsers()
        {
            var result =await _userManager.Users.ToListAsync();
            return result;
        }

        [HttpGet]
        [Route("GetUserById")]
        public async Task<IActionResult> GetUserById()
        {
            return null;
        }

        [HttpPut]
        [Route("UpdateUser /{id:Guid}")]
        public async Task<IActionResult> UpdateUser([FromBody] int id)
        {
            return null;
        }

        [HttpDelete]
        [Route("DeleteUser /{id:Guid}")]
        public async Task<IActionResult> DeleteUser([FromBody] int id)
        {
            return null;
        }
    }
}