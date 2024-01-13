using AutoMapper;
using imc_web_api.Dtos.ServiceProviderDtos;
using imc_web_api.Models;
using imc_web_api.Service.ServiceProviderService.ManageServices_Service;
using Microsoft.AspNetCore.Mvc;

namespace imc_web_api.Controllers.ServiceProviderController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageServicesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IManageService _manageServices;

        public ManageServicesController(IMapper mapper, IManageService manageServices)
        {
            _mapper = mapper;
            _manageServices = manageServices;
        }

        //--> Add Service

        [HttpPost]
        [Route("AddService")]
        public async Task<IActionResult> AddService([FromBody] ServiceRequestDTO ServiceInputRequest)
        {
            var ServiceModel = _mapper.Map<service>(ServiceInputRequest);
            var ServiceDtoResult = await _manageServices.AddService(ServiceModel);

            var ServiceDtp_Result = _mapper.Map<service>(ServiceDtoResult);
            return Ok(new
            {
                Data = ServiceDtp_Result,
                Message = "Service Added Successfully!"
            });
        }

        //-->Update Service
        [HttpPut]
        [Route("UpdateService/{id:Guid}")]
        public async Task<IActionResult> UpdateService(Guid id, [FromBody] ServiceRequestDTO ServiceInputRequest)
        {
            var ServiceModel = _mapper.Map<service>(ServiceInputRequest);

            var UpdatedService = await _manageServices.UpdateService(id, ServiceModel);
            return Ok(new
            {
                Data = UpdatedService,
                Message = "Service Updated!"
            });
        }

        //-->GetAll Service
        [HttpGet]
        [Route("GetServices")]
        public async Task<List<ServiceResponseDTO>> GetServices()
        {
            var ServiceModel = await _manageServices.GetServices();
            var ServiceDtoResult = _mapper.Map<List<ServiceResponseDTO>>(ServiceModel);
            return ServiceDtoResult;
        }

        // -->Get Service By Id
        [HttpGet]
        [Route("GetServiceById/{id:Guid}")]
        public async Task<ServiceResponseDTO> GetServiceById(Guid id)
        {
            var ServiceModel = await _manageServices.GetServiceById(id);
            var ServiceDtoResult = _mapper.Map<ServiceResponseDTO>(ServiceModel);

            return ServiceDtoResult;
        }

        //-->Delete Service
        [HttpDelete]
        [Route("DeleteService")]
        public async Task<IActionResult> DeleteService(Guid id)
        {
            var DeleteService = await _manageServices.DeleteService(id);
            return Ok(new
            {
                Data = DeleteService,
                Message = "Service Deleted Successfully!"
            });
        }
    }
}