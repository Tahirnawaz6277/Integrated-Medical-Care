using imc_web_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace imc_web_api.Controllers.AdminController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageAgreementController : ControllerBase
    {
        public ImcDbContext _ImcDbContext;

        public ManageAgreementController(ImcDbContext imcDbContext)
        {
            _ImcDbContext = imcDbContext;
        }

        // GET Agreements
        [HttpGet]
        [Route("GetAgreements")]
        public async Task<List<agreement>> GetAgreements()
        {
            return null;
        }

        // GET AgreementById
        [HttpGet]
        [Route("GetAgreement/{id:Guid}")]
        public async Task<agreement> GetAgreement(Guid id)
        {
            return null;
        }

        // POST Agreement
        [HttpPost]
        [Route("AddAgreement")]
        public async Task<IActionResult> AddAgreement([FromBody] agreement value)
        {
            return null;
        }

        // DELETE  Agreement
        [HttpDelete]
        [Route("DeleteAgreement/{id:Guid}")]
        public async Task<IActionResult> DeleteAgreement(Guid id)
        {
            return null;
        }
    }
}