using AutoMapper;
using imc_web_api.Dtos.AdminDtos.HCPDtos;
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
        private readonly IManageServices_Service _manageServices;

        public ManageServicesController(IMapper mapper, IManageServices_Service manageServices)
        {
            _mapper = mapper;
            _manageServices = manageServices;
        }

        // changes

        [HttpPost]
        [Route("AddService/")]
        public async Task<IActionResult> CreateService([FromBody] ServiceRequestDTO serviceRequest)
        {
            //Dto to model mapping
            var ServiceModel = _mapper.Map<service>(serviceRequest);
            var ServiceDtoResult = await _manageServices.AddService(ServiceModel);
            //model to dto mapping
            var Servicedto = _mapper.Map<service>(ServiceDtoResult);
            return Ok(new
            {
                Data = ServiceDtoResult,
                Message = "Service Added Successfully!"
                Message = "Provider Added Successfully!"
            });
        }

        //-->Update Service
        [HttpPut]
        [Route("UpdateService/{id:Guid}")]
        public async Task<service> UpdateService(Guid id, [FromBody] ServiceRequestDTO ServiceInputRequest)
        {
            var model = _mapper.Map<service>(ServiceInputRequest);

            var se = await _manageServices.UpdateService(id, model);
            return se;
        public async Task<HCPResponseDTO> UpdateService(Guid id, [FromBody] ServiceRequestDTO ServiceInputRequest)
        {
            return null;
        }

        //-->GetAll Service
        [HttpGet]
        [Route("GetServices")]
        public async Task<List<ServiceResponseDTO>> GetServices()
        {
            var Service_Model_Result = await _manageServices.GetServices();
            var Service_DTO_Result = _mapper.Map<List<ServiceResponseDTO>>(Service_Model_Result = await _manageServices.GetServices());
            return Service_DTO_Result;
        }

        // -->Get Service By Id
        [HttpGet]
        [Route("GetServiceById/{id:Guid}")]
        public async Task<IActionResult> GetServiceById(Guid id)
        {
            var service = await _manageServices.GetServiceById(id);
            if (service == null)
            {
                return NotFound();
            }
            return Ok(new
            {
                Data = service,
                Message = "Service Retreiving Sucessfully!"
            });
            return null;
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
            ;
            return null;
        }
    }
}