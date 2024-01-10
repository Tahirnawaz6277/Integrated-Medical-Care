using imc_web_api.Dtos.HCPDtos;
using imc_web_api.Models;
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
            //return await _manageHCPService.AddProvider(UserInputReguest);
            return null;
        }

        //-->Update HCP
        [HttpPut]
        [Route("UpdateHCP/{id:Guid}")]
        public async Task<serviceprovidertype> UpdateHCP(Guid id,[FromBody] HCPRequestDTO InputRequest)
        {
            return await _manageHCPService.UpdateProvider(id, InputRequest);
        }

        //-->GetAll HCP
        [HttpGet]
        [Route("GetHCP")]
        public async Task<List<serviceprovidertype>> GetHCP()
        {
            return await _manageHCPService.GetProviders();
        }

        //-->Get HCP By Id
        [HttpGet]
        [Route("GetHCP/{id:Guid}")]
        public async Task<serviceprovidertype> GetUserById(Guid id)
        {
            return await _manageHCPService.GetProviderById(id);
        }

        //-->Delete HCP
        [HttpDelete]
        [Route("DeleteHCP")]
        public async Task<serviceprovidertype> DeleteHCP(Guid id)
        {
            return await _manageHCPService.DeleteProvider(id);
        }
    }
}