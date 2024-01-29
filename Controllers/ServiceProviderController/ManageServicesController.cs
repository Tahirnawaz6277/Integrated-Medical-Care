using System.Security.Claims;
using AutoMapper;
using imc_web_api.Dtos.ServiceProviderDtos;
using imc_web_api.Models;
using imc_web_api.Service.ServiceProviderService.ManageServices_Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace imc_web_api.Controllers.ServiceProviderController
{
    [Authorize(AuthenticationSchemes = "Bearer")]
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
        [Authorize(Roles = "Admin,ServiceProvider")]
        public async Task<IActionResult> AddService([FromBody] ServiceRequestDTO ServiceInputRequest)
        {
            Guid CurrentUserId = Guid.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var ServiceModel = _mapper.Map<service>(ServiceInputRequest);
            var ServiceDtoResult = await _manageServices.AddService(ServiceModel, CurrentUserId);

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
        [Authorize(Roles = "Admin,ServiceProvider")]
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
        [Authorize(Roles = "Admin,ServiceProvider")]
        public async Task<List<ServiceResponseDTO>> GetServices()
        {
            var ServiceModel = await _manageServices.GetServices();
            var ServiceDtoResult = _mapper.Map<List<ServiceResponseDTO>>(ServiceModel);
            return ServiceDtoResult;
        }

        // -->Get Service By Id
        [HttpGet]
        [Route("GetServiceById/{id:Guid}")]
        [Authorize(Roles = "Admin,ServiceProvider")]
        public async Task<ServiceResponseDTO> GetServiceById(Guid id)
        {
            var ServiceModel = await _manageServices.GetServiceById(id);
            var ServiceDtoResult = _mapper.Map<ServiceResponseDTO>(ServiceModel);

            return ServiceDtoResult;
        }

        //-->Delete Service
        [HttpDelete]
        [Route("DeleteService")]
        [Authorize(Roles = "Admin,ServiceProvider")]
        public async Task<IActionResult> DeleteService(Guid id)
        {
            Guid CurrentUserId = Guid.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var DeleteService = await _manageServices.DeleteService(id, CurrentUserId);

            return DeleteService != null
     ? Ok(new
     {
         Data = DeleteService,
         Message = "Service Deleted Successfully!"
     })
     : StatusCode(403, "Permission denied to delete the service.");
        }
    }
}