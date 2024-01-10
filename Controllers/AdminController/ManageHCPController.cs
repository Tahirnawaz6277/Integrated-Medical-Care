using imc_web_api.Dtos.HCPDtos;
using imc_web_api.Service.AdminServices.ManageHCPServices;
using Microsoft.AspNetCore.Mvc;

namespace imc_web_api.Controllers.AdminController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageHCPController : ControllerBase
    {
        private readonly IManageHCPService _manageHCPService;
        private readonly ImcDbContext _imcDbContext;

        public ManageHCPController(IManageHCPService manageHCPService, ImcDbContext imcDbContext)
        {
            _manageHCPService = manageHCPService;
            _imcDbContext = imcDbContext;
        }

        //-->Add HCP
        [HttpPost]
        [Route("AddHCP")]
        public async Task<IActionResult> AddHCP([FromBody] HCPRequestDTO UserInputReguest)
        {
            var HCP_Result = await _manageHCPService.AddProvider(UserInputReguest);

            var HCPDto_Result = new HCPRequestDTO
            {
                ProviderName = HCP_Result.ProviderName
            };
            return Ok(new
            {
                Data = HCPDto_Result,
                Message = "Provider Added Successfully!"
            });
        }

        //-->Update HCP
        [HttpPut]
        [Route("UpdateHCP")]
        public Task<IActionResult> UpdateHCP()
        {
            return null;
        }

        //-->GetAll HCP
        [HttpGet]
        [Route("GetHCPs")]
        public Task<IActionResult> GetHCPs()
        {
            return null;
        }

        //-->Get HCP By Id
        [HttpGet]
        [Route("GetHCP/{id:Guid}")]
        public Task<IActionResult> GetHCP(Guid id)
        {
            return null;
        }

        //-->Delete HCP
        [HttpDelete]
        [Route("DeleteHCP")]
        public Task<IActionResult> DeleteHCP(Guid id)
        {
            return null;
        }
    }
}