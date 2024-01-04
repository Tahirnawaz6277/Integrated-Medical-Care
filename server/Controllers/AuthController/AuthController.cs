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
        [Route("SignUp")]
        public async Task<IActionResult> Register(RegistrationDTO register)
        {

            if (register == null)
            {
                return BadRequest(ModelState);
            }

            //user object
            var user = new User
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




        // Login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login()
        {
            return Ok();
        }
    }
}
