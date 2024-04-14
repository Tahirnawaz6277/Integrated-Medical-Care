using AutoMapper;
using imc_web_api.Dtos.AdminDtos.HCPDtos;

//using imc_web_api.Dtos.HCPDtos;
using imc_web_api.Models;
using imc_web_api.Service.AdminServices.ManageHCPServices;
using Microsoft.AspNetCore.Mvc;

namespace imc_web_api.Controllers.AdminController
{
    //[Authorize(AuthenticationSchemes = "Bearer")]
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
            try
            {
                if (UserInputReguest == null)
                {
                    return BadRequest(ModelState);
                }
                var HCP_Model = _mapper.Map<serviceprovidertype>(UserInputReguest);
                var HCP_Result = await _manageHCPService.AddProvider(HCP_Model);

                //var HCPDto_Result = _mapper.Map<HCPRequestDTO>(HCP_Result);

                return Ok(new
                {
                    success = true,
                    Message = "Provider Added Successfully!",
                    Data = HCP_Result

                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    ErrorMessage = ex.Message
                });
            }
        }

        //-->Update HCP
        [HttpPut]
        [Route("UpdateHCP/{id:Guid}")]
        public async Task<IActionResult> UpdateHCP(Guid id, [FromBody] HCPRequestDTO InputRequest)
        {
            try
            {
                if (InputRequest == null || id == Guid.Empty)
                {
                    return BadRequest("Input Field is Required ");
                }
                var HCP_Model_Result = await _manageHCPService.UpdateProvider(id, InputRequest);

                if (HCP_Model_Result == null)
                {
                    return NotFound("Record Not Found!");
                }
                var HCP_DTO_Result = _mapper.Map<HCPResponseDTO>(HCP_Model_Result);
                return Ok(new
                {
                    success = true,
                    Message = "Health care Record Updated!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    ErrorMessage = ex.Message
                });
            }
        }

        //-->GetAll HCP
        [HttpGet]
        [Route("GetHCPs")]
        public async Task<IActionResult> GetHCPs()
        {
            try
            {
                var HCP_Model_Result = await _manageHCPService.GetProviders();
                //var HCP_DTO_Result = _mapper.Map<List<HCPResponseDTO>>(HCP_Model_Result);

                return Ok(new
                {
                    Success = true,
                    Data = HCP_Model_Result,
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    ErrorMessage = ex.Message
                });
            }
        }

        // -->Get HCP By Id
        [HttpGet]
        [Route("GetHCP/{id:Guid}")]
        public async Task<IActionResult> GetHCPById(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest("Id Field is Required!s");
                }
                var HCP_Model_Result = await _manageHCPService.GetProviderById(id);

                //var HCP_DTO_Result = _mapper.Map<HCPResponseDTO>(HCP_Model_Result);

                return Ok(new
                {
                    success = true,
                    Data = HCP_Model_Result,
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    ErrorMessage = ex.Message
                });
            }
        }

        //-->Delete HCP
        [HttpDelete]
        [Route("DeleteHCP")]
        public async Task<IActionResult> DeleteHCP(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest("Id Field is Required!s");
                }

                var HCP_Model_Result = await _manageHCPService.DeleteProvider(id);

                if (HCP_Model_Result == null)
                {
                    return NotFound("Record Not Found!");
                }
                var HCP_DTO_Result = _mapper.Map<HCPResponseDTO>(HCP_Model_Result);

                return Ok(new
                {
                    Success = true,
                    Message = "Health Care Provider Deleted Successfully!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    ErrorMessage = ex.Message
                });
            }
        }
    }
}