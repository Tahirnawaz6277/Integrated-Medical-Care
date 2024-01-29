using imc_web_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace imc_web_api.Controllers.AdminController
{
    //[Authorize(AuthenticationSchemes = "Bearer")]
    //[Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ManageAgreementController : ControllerBase
    {
        public ImcDbContext _ImcDbContext;

        public ManageAgreementController(ImcDbContext imcDbContext)
        {
            _ImcDbContext = imcDbContext;
        }

        // GET AGREEMENTS
        [HttpGet]
        [Route("GetAgreements")]
        public async Task<List<agreement>> GetAgreements()
        {
            return null;
        }

        // GET AGREEMENTS BY ID
        [HttpGet]
        [Route("GetAgreement/{id:Guid}")]
        public async Task<agreement> GetAgreement(Guid id)
        {
            return null;
        }

        // POST AGREEMENTS
        [HttpPost]
        [Route("AddAgreement")]
        public async Task<IActionResult> AddAgreement([FromBody] agreement value)
        {
            return null;
        }

        // DELETE AGREEMENTS
        [HttpDelete]
        [Route("DeleteAgreement/{id:Guid}")]
        public async Task<IActionResult> DeleteAgreement(Guid id)
        {
            return null;
        }
    }
}