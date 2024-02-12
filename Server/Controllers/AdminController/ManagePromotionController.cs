using System.Security.Claims;
using AutoMapper;
using imc_web_api.Dtos.AdminDtos.PromotionDtos;
using imc_web_api.Models;
using imc_web_api.Service.AdminServices.ManagePromotionServices;
using imc_web_api.Service.EmailServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace imc_web_api.Controllers.AdminController
{
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class ManagePromotionController : ControllerBase
    {
        private readonly IManagePromotionService _managePromotionService;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public ManagePromotionController(IManagePromotionService managePromotionService, IMapper mapper, IEmailSender emailSender )
        {
            _managePromotionService = managePromotionService;
            _mapper = mapper;
            _emailSender = emailSender;
        }

        //--> Add Promotion

        [HttpPost]
        [Route("AddPromotion")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddPromotion([FromBody] PromotionRequestDTO Promotion_Input_Request)
        {
            try
            {
                var CurrentUserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (string.IsNullOrEmpty(CurrentUserId))
                {
                    return Unauthorized("User is not authenticated.");
                }

                if (Promotion_Input_Request == null)
                {
                    return BadRequest("Input Field is Required!");
                }
                var Promotion_Model = _mapper.Map<promotion>(Promotion_Input_Request);
                var Promotion_Result = await _managePromotionService.AddPromotion(Promotion_Model, CurrentUserId);

                if(Promotion_Result != null)
                {
                    //_emailSender.SendEmail("inamwebpro007@gmail.com", "Administrator Promotion Offer");
                }
                var PromotionDto_Result = _mapper.Map<PromotionResponseDTO>(Promotion_Result);

                return Ok(new
                {
                    Success = true,
                    Message = "Promotion Send!"
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

        //--> Update Promotion

        [HttpPut]
        [Route("UpdatePromotion/{id:Guid}")]
        public async Task<IActionResult> UpdatePromotion(Guid id, [FromBody] PromotionRequestDTO PromotionRequestDTO)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest("Id Field is Required!");
                }

                if (PromotionRequestDTO == null)
                {
                    return BadRequest("Input Field is Required!");
                }

                var Promotion_Model = _mapper.Map<promotion>(PromotionRequestDTO);
                var Promotion_Result = await _managePromotionService.UpdatePromotion(id, Promotion_Model);

                if (Promotion_Result == null)
                {
                    return NotFound("Record Not Found");
                }
                var PromotionDto_Result = _mapper.Map<PromotionResponseDTO>(Promotion_Result);

                return Ok(new
                {
                    Success = true,
                    Message = "Promotion Updated!"
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

        //--> Get Promotions
        [HttpGet]
        [Route("GetPromotions")]
        public async Task<IActionResult> GetPromotions()
        {
            try
            {
                var Promotion_Result = await _managePromotionService.GetPromotions();

                var PromotionDto_Result = _mapper.Map<List<PromotionResponseDTO>>(Promotion_Result);

                return Ok(new
                {
                    Success = true,
                    Data = PromotionDto_Result,
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

        //--> Get Promotion By Id
        [HttpGet]
        [Route("GetPromotionById/{id:Guid}")]
        public async Task<IActionResult> GetPromotionById(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest("Id Field is Required!");
                }
                var Promotion_Result = await _managePromotionService.GetPromotionById(id);

                var PromotionDto_Result = _mapper.Map<PromotionResponseDTO>(Promotion_Result);

                return Ok(new
                {
                    Success = true,
                    Data = PromotionDto_Result,
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

        //--> Delete Promotion
        [HttpDelete]
        [Route("DeletePromotion/{id:Guid}")]
        public async Task<IActionResult> DeletePromotion(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest("Id Field is Required!");
                }
                var Promotion_Result = await _managePromotionService.DeletePromotion(id);

                if (Promotion_Result == null)
                {
                    return NotFound("Record Not Found");
                }
                var PromotionDto_Result = _mapper.Map<PromotionResponseDTO>(Promotion_Result);

                return Ok(new
                {
                    Success = true,
                    Message = "Promotion Deleted!",
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