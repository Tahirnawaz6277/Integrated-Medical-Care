using imc_web_api.Dtos.AdminDtos.HCPDtos;
using imc_web_api.Dtos.ServiceProviderDtos;
using Microsoft.AspNetCore.Mvc;

namespace imc_web_api.Controllers.ServiceProviderController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageServiceController : ControllerBase
    {
        //-->Add Service
        [HttpPost]
        [Route("AddService")]
        public async Task<IActionResult> AddService([FromBody] ServiceRequestDTO ServiceInputRequest)
        {
            return null;
        }

        //-->Update Service
        [HttpPut]
        [Route("UpdateService/{id:Guid}")]
        public async Task<HCPResponseDTO> UpdateService(Guid id, [FromBody] ServiceRequestDTO ServiceInputRequest)
        {
            return null;
        }

        //-->GetAll Service
        [HttpGet]
        [Route("GetServices")]
        public async Task<IActionResult> GetServices()
        {
            return null;
        }

        // -->Get Service By Id
        [HttpGet]
        [Route("GetServiceById/{id:Guid}")]
        public async Task<IActionResult> GetServiceById(Guid id)
        {
            return null;
        }

        //-->Delete Service
        [HttpDelete]
        [Route("DeleteService")]
        public async Task<IActionResult> DeleteService(Guid id)
        {
            return null;
        }
    }
}