//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using server.DTO.AuthDTO;
//using server.Models;

//namespace server.Controllers.AuthControllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class RolesController : ControllerBase
//    {
//        private readonly imcContextClass imcContext;
//        public RolesController(imcContextClass imcContext)
//        {
//            this.imcContext = imcContext;
//         }

//        [HttpPost]
//        [Route("Role")]
//        public async Task<IActionResult> AddRole([FromBody] Role data  )
//        {
//            if (data == null)
//            {
//                return BadRequest();
//            }

//            await imcContext.Roles.AddAsync(data);
//            imcContext.SaveChanges();
//            return Ok(new
//            {
//                Message = "Role Added!",
//                Data = data,
//            });
//        }

//    }
//}
