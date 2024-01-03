using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IMC_Integrated_Medical_Care_.Controllers.AuthController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        public AuthController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }


        // Register 
        [HttpPost]
        public async Task<IActionResult> Register()
        {
            return Ok();
        }

        // Login
        [HttpPost]
        public async Task<IActionResult> Login()
        {
            return Ok();
        }
    }
}
