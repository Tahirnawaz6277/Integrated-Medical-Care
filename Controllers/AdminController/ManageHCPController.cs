using AutoMapper;
using imc_web_api.Dtos.AdminDtos.HCPDtos;

//using imc_web_api.Dtos.HCPDtos;
using imc_web_api.Models;
using imc_web_api.Service.AdminServices.ManageHCPServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace imc_web_api.Controllers.AdminController
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class ManageHCPController : ControllerBase
    {
        private readonly IManageHCPService _manageHCPService;
        private readonly ImcDbContext _imcDbContext;
        private readonly IMapper _mapper;

        public ManageHCPController(IManageHCPService manageHCPService, ImcDbContext imcDbContext, IMapper mapper)
        {
            _manageHCPService = manageHCPService;
            _imcDbContext = imcDbContext;
            _mapper = mapper;
        }

        //-->Add HCP
        [HttpPost]
        [Route("AddHCP")]
        public async Task<IActionResult> AddHCP([FromBody] HCPRequestDTO UserInputReguest)
        {
            var HCP_Model = _mapper.Map<serviceprovidertype>(UserInputReguest);
            var HCP_Result = await _manageHCPService.AddProvider(HCP_Model);

            var HCPDto_Result = _mapper.Map<HCPRequestDTO>(HCP_Result);

            return Ok(new
            {
                Data = HCPDto_Result,
                Message = "Provider Added Successfully!"
            });
        }

        //-->Update HCP
        [HttpPut]
        [Route("UpdateHCP/{id:Guid}")]
        public async Task<HCPResponseDTO> UpdateHCP(Guid id, [FromBody] HCPRequestDTO InputRequest)
        {
            var HCP_Model_Result = await _manageHCPService.UpdateProvider(id, InputRequest);
            var HCP_DTO_Result = _mapper.Map<HCPResponseDTO>(HCP_Model_Result);
            return HCP_DTO_Result;
        }

        //-->GetAll HCP
        [HttpGet]
        [Route("GetHCPs")]
        public async Task<List<HCPResponseDTO>> GetHCPs()
        {
            var HCP_Model_Result = await _manageHCPService.GetProviders();
            var HCP_DTO_Result = _mapper.Map<List<HCPResponseDTO>>(HCP_Model_Result);
            return HCP_DTO_Result;
        }

        // -->Get HCP By Id
        [HttpGet]
        [Route("GetHCP/{id:Guid}")]
        public async Task<HCPResponseDTO> GetHCPById(Guid id)
        {
            var HCP_Model_Result = await _manageHCPService.GetProviderById(id);
            var HCP_DTO_Result = _mapper.Map<HCPResponseDTO>(HCP_Model_Result);
            return HCP_DTO_Result;
        }

        //-->Delete HCP
        [HttpDelete]
        [Route("DeleteHCP")]
        public async Task<HCPResponseDTO> DeleteHCP(Guid id)
        {
            var HCP_Model_Result = await _manageHCPService.DeleteProvider(id);
            var HCP_DTO_Result = _mapper.Map<HCPResponseDTO>(HCP_Model_Result);
            return HCP_DTO_Result;
        }
    }
}