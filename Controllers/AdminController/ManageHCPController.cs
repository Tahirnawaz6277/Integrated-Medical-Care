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

        public ManageHCPController(IManageHCPService manageHCPService)
        {
            _manageHCPService = manageHCPService;
        }

        //-->Add HCP
        [HttpPost]
        [Route("AddHCP")]
        public async Task<IActionResult> AddHCP([FromBody] HCPRequestDTO UserInputReguest)
        {
                
           
            return null;
        }

        //-->Update HCP
        [HttpPost]
        [Route("UpdateHCP")]
        public Task<IActionResult> UpdateHCP()
        {
            return null;
        }

        //-->GetAll HCP
        [HttpPost]
        [Route("GetHCP")]
        public Task<IActionResult> GetHCP()
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
        [HttpPost]
        [Route("DeleteHCP")]
        public Task<IActionResult> DeleteHCP(Guid id)
        {
            return null;
        }
    }
}