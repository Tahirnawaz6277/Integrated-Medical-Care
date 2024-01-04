using IMC_Integrated_Medical_Care_.Dtos;
using IMC_Integrated_Medical_Care_.Models;
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
        public async Task<IActionResult> Register(RegistrationDTO register)
        {

            if (register == null)
            {
                return BadRequest(ModelState);
            }

            var user = new User
            {
                firstName = register.firstName,
                lastName = register.lastName,
                Email = register.Email,
                password = register.password,
                contact = register.contact,
                gender = register.gender,
                role = register.role,

            };

            // check the User is Already Exist

            //var isExistingUser = await   
            
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
