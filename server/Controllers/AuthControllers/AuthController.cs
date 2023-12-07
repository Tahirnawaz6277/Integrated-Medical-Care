using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.DTO.AuthDTO;
using server.Models;

namespace server.Controllers.AuthControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly UserManager<User> _userManager;
        private readonly ImcContextClass contextClass;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AuthController(ImcContextClass contextClass , UserManager<User> userManager , RoleManager<IdentityRole> roleManager)
        {
              this.contextClass = contextClass;
            _userManager = userManager;
            _roleManager = roleManager;
        }




        [HttpPost]
        [Route("Registration")]
        public async Task<IActionResult> Registration([FromBody] RegisterationDTO userRecord)
        {
            if (userRecord == null)
            {
                return BadRequest();
            }
            var userObj = new User
            {
                 FirstName = userRecord.FirstName,
                 LastName= userRecord.LastName,
                 Contact= userRecord.Contact,
                 Gender= userRecord.Gender,
                 RoleId= userRecord.RoleId,
                 UserName = userRecord.Email,
                 Email = userRecord.Email,
            };

            // create user
            var result = await _userManager.CreateAsync(userObj, userRecord.Password );
            if (result.Succeeded)
            {
                // ---- Get User Role
                var userRole = await _roleManager.FindByIdAsync(userRecord.RoleId.ToString());

                if (userRole != null && userRole.Name.Any())
                {
                    result = await _userManager.AddToRoleAsync(userObj, userRole.Name);

                    if (result.Succeeded)
                    {
                        return Ok(new
                        {
                            Message = "User Registered Successfully",
                  
                        });
                    }
                   
                        return BadRequest("Failed to assign roles to the user.");
               
                }
            }
            return BadRequest(result);

        }



        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login()
        {
            return Ok();
        }
    }
}
