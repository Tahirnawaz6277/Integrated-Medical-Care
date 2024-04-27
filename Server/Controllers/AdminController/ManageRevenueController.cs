using System.Security.Claims;
using AutoMapper;
using imc_web_api.Dtos.AdminDtos.RevenueDtos;
using imc_web_api.Models;
using imc_web_api.Service.AdminServices.ManageRevenueServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace imc_web_api.Controllers.AdminController
{
    [Route("api/[controller]")]

    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    public class ManageRevenueController : ControllerBase
    {
        private readonly IManageRevenueService _manageRevenueService;

        private readonly IMapper _mapper;

        public ManageRevenueController(IManageRevenueService manageRevenueService, IMapper mapper)
        {
            _manageRevenueService = manageRevenueService;
            _mapper = mapper;
        }

        // POST Revenue
        [HttpPost]
        [Route("AddRevenue")]
        [Authorize(Roles = "Admin,ServiceProvider")]
        public async Task<IActionResult> AddRevenue([FromBody] RevenueRequestDto RevenueRequest)
        {
            try
            {

                

                if (RevenueRequest == null)
                {
                    return BadRequest(ModelState);
                }

                var CurrentUserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (string.IsNullOrEmpty(CurrentUserId))
                {
                    return Unauthorized("User is not authenticated.");
                }

                var Revenue_Model = _mapper.Map<Revenue>(RevenueRequest);
                var Revenue_Result = await _manageRevenueService.AddRevenueAsync(Revenue_Model , CurrentUserId);

                var Result = _mapper.Map<RevenueResponseDto>(Revenue_Result);

                return Ok(new
                {
                    success = true,
                    Message = "Revenue Added Successfully!",
                    Data = Result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    ErrorMessage = ex.InnerException.Message
                });
            }
        }

        // GET Revenues
        [HttpGet]
        [Route("GetRevenues")]
        [Authorize(Roles = "Admin,ServiceProvider")]
        public async Task<IActionResult> GetRevenues()
        {
            try
            {
                var Revenue_Items = await _manageRevenueService.GetRevenuesAsync();

                var Revenue_Result = _mapper.Map<List<RevenueResponseDto>>(Revenue_Items);

                return Ok(new
                {
                    Success = true,
                    Data = Revenue_Result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    ErrorMessage = ex.InnerException.Message
                });
            }
        }

        // GET Revenue By Id
        [HttpGet]
        [Route("GetRevenueById/{id:Guid}")]
        [Authorize(Roles = "Admin,ServiceProvider")]
        public async Task<IActionResult> GetRevenueById(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest("Id Field is Required!");
                }
                var Revenue_Items = await _manageRevenueService.GetRevenueByIdAsync(id);

                var Revenue_Result = _mapper.Map<RevenueResponseDto>(Revenue_Items);

                return Ok(new
                {
                    Success = true,
                    Data = Revenue_Result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    ErrorMessage = ex.InnerException.Message
                });
            }
        }

        // DELETE Revenue
        [HttpDelete]
        [Route("DeleteRevenue/{id:Guid}")]
        [Authorize(Roles = "Admin,ServiceProvider")]
        public async Task<IActionResult> DeleteRevenue(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest("Id Field is Required!");
                }

                var Revenue = await _manageRevenueService.DeleteRevenueAsync(id);

                return Ok(new
                {
                    Success = true,
                    Message = "Revenue Deleted Successfully!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    ErrorMessage = ex.InnerException.Message
                });
            }
        }

        // Update Revenue
        [HttpPut]
        [Route("UpdateRevenue/{id:Guid}")]
        [Authorize(Roles = "Admin,ServiceProvider")]
        public async Task<IActionResult> UpdateRevenue(Guid id, RevenueRequestDto RevenueRequest)
        {
            try
            {
                if (RevenueRequest == null || id == Guid.Empty)
                {
                    return BadRequest("Input Field is Required ");
                }

                var Revenue_Model = _mapper.Map<Revenue>(RevenueRequest);

                var Revenue_Result = await _manageRevenueService.UpdateRevenueAsync(id, Revenue_Model);

                if (Revenue_Result == null)
                {
                    return NotFound("Record Not Found!");
                }
                var result = _mapper.Map<RevenueResponseDto>(Revenue_Result);
                return Ok(new
                {
                    success = true,
                    Message = "Revenue Record Updated!",
                    Data = result
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