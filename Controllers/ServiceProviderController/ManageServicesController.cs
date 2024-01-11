using AutoMapper;
using imc_web_api.Dtos.AdminDtos.HCPDtos;
using imc_web_api.Dtos.ServiceProviderDtos;
using imc_web_api.Models;
using imc_web_api.Service.ServiceProviderService.ManageServices;
using Microsoft.AspNetCore.Mvc;

namespace imc_web_api.Controllers.ServiceProviderController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageServicesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ManageServices_Service _manageServices;

        public ManageServicesController(IMapper mapper,ManageServices_Service manageServices)
        {
            _mapper = mapper;
            _manageServices = manageServices;
        }
        public async Task<IActionResult> AddHCP([FromBody] HCPRequestDTO UserInputReguest)
        {
            var HCP_Model = _mapper.Map<service>(UserInputReguest);
            var HCP_Result = await _manageServices.AddProvider(HCP_Model);

            var HCPDto_Result = _mapper.Map<ServiceRequestDTO>(HCP_Result);

            return Ok(new
            {
                Data = HCPDto_Result,
                Message = "Provider Added Successfully!"
            });
        }
    }
}