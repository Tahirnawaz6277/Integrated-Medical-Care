using System.Security.Claims;
using AutoMapper;

using imc_web_api.Dtos.AdminDtos.FeedBackDtos;
using imc_web_api.Models;
using imc_web_api.Service.AdminServices.NewFolder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace imc_web_api.Controllers.AdminController
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class ManageFeedBackController : ControllerBase
    {
        private readonly IManageFeedbackService _feedbackService;
        private readonly IMapper _mapper;

        public ManageFeedBackController(IManageFeedbackService feedbackService, IMapper mapper)
        {
            _feedbackService = feedbackService;
            _mapper = mapper;
        }

        //--> Add Feedback

        [HttpPost]
        [Route("AddFeedback")]
        [Authorize(Roles = "Admin , Customer")]
        public async Task<IActionResult> CreateFeedback([FromBody] FeedBackRequesrDTO inputRequest)
        {
            try
            {
                if (inputRequest == null)
                {
                    return BadRequest(ModelState);
                }

                var CurrentUserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (string.IsNullOrEmpty(CurrentUserId))
                {
                    return Unauthorized("User is not authenticated.");
                }
                var feedbackModel = _mapper.Map<feedback>(inputRequest);
                var addedFeedbackModel = await _feedbackService.AddFeedback(feedbackModel, CurrentUserId);
                if (addedFeedbackModel == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Failed to add feedback.");
                }

                var addedFeedbackDTO = _mapper.Map<FeedBackResponseDTO>(addedFeedbackModel);

                return Ok(new
                {
                    Success = true,
                    Message = "Feedback added successfully.",
                  
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    ErrorMessage = ex.Message,
                });
            }
        }

        //-->Update Feedback
        [HttpPut]
        [Route("UpdateFeedback/{id:Guid}")]
        public async Task<IActionResult> UpdateFeedback(Guid id, [FromBody] FeedBackRequesrDTO InputRequest)
        {
            try
            {
                if (InputRequest == null || id == Guid.Empty)
                {
                    return BadRequest("null");
                }
                var Feedback_Model = _mapper.Map<feedback>(InputRequest);

                var Feedback_Result = await _feedbackService.UpdateFeedback(id, Feedback_Model);

                if (Feedback_Result == null)
                {
                    return NotFound("Feedback Record Not Found!");
                }
                var FeedbackDto_Result = _mapper.Map<FeedBackResponseDTO>(Feedback_Result);

                return Ok(new
                {
                    Success = true,
                    Message = "Feedback Updated successfully.",
                   
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    ErrorMessage = ex.Message,
                });
            }
        }

        //-->GetAll Feedback
        [HttpGet]
        [Route("GetFeedbacks/")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetFeedbacks()
        {
            try
            {
                var FeedbackResult = await _feedbackService.GetFeedbacks();

                var FeedbackDtoResult = _mapper.Map<List<FeedBackResponseDTO>>(FeedbackResult);

                return Ok(new
                {
                    Success = true,
                    Data = FeedbackDtoResult
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    ErrorMessage = ex.Message,
                });
            }
        }

        // --> Get Feedback By Id
        [HttpGet]
        [Route("GetFeedbackById/{id:Guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetFeedbackById(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest(ModelState);
                }

                var FeedbackResult = await _feedbackService.GetFeedbackById(id);
                if (FeedbackResult == null)
                {
                    return NotFound("Record Not Found!");
                }
                var FeedbackDtoResult = _mapper.Map<FeedBackResponseDTO>(FeedbackResult);

                return Ok(new
                {
                    Success = true,
                    Data = FeedbackDtoResult
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    ErrorMessage = ex.Message,
                });
            }
        }

        //--> Delete Feedback
        [HttpDelete]
        [Route("DeleteFeedback/")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteFeedback(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest(ModelState);
                }

                var FeedbackResult = await _feedbackService.DeleteFeedback(id);

                if (FeedbackResult == null)
                {
                    return NotFound("Record Not Found!");
                }

                var FeedbackDtoResult = _mapper.Map<FeedBackResponseDTO>(FeedbackResult);
                return Ok(new
                {
                    Success = true,
                    Message = "Feedback Deleted!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    ErrorMessage = ex.Message,
                });
            }
        }
    }
}