using AutoMapper;
using imc_web_api.Dtos.AdminDtos.FeedBackDtos;
using imc_web_api.Models;
using imc_web_api.Service.AdminServices.NewFolder;
using Microsoft.AspNetCore.Mvc;

namespace imc_web_api.Controllers.AdminController
{
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

        // --> Add Feedback
        [HttpPost]
        [Route("AddFeedback/")]
        public async Task<IActionResult> CreateFeedback([FromBody] FeedBackRequesrDTO inputRequest)
        {
            var feedbackModel = _mapper.Map<feedback>(inputRequest);

            var addedFeedbackModel = await _feedbackService.AddFeedback(feedbackModel);

            var addedFeedbackDTO = _mapper.Map<FeedBackResponseDTO>(addedFeedbackModel);

            return Ok(new
            {
                Data = addedFeedbackDTO,
                Message = "Feedback added successfully."
            });
        }

        //-->Update Feedback
        [HttpPut]
        [Route("UpdateFeedback/{id:Guid}")]
        public async Task<IActionResult> UpdateFeedback(Guid id, [FromBody] FeedBackRequesrDTO InputRequest)
        {
            var Feedback_Model = _mapper.Map<feedback>(InputRequest);
            var Feedback_Result = await _feedbackService.UpdateFeedback(id, Feedback_Model);

            var FeedbackDto_Result = _mapper.Map<FeedBackResponseDTO>(Feedback_Result);

            return Ok(new
            {
                Data = FeedbackDto_Result,
                Message = "Feedback Updated!"
            });
        }

        //-->GetAll Feedback
        [HttpGet]
        [Route("GetFeedbacks/")]
        public async Task<List<FeedBackResponseDTO>> GetFeedbacks()
        {
            var FeedbackResult = await _feedbackService.GetFeedbacks();
            var FeedbackDtoResult = _mapper.Map<List<FeedBackResponseDTO>>(FeedbackResult);
            return FeedbackDtoResult;
        }

        // -->Get Feedback By Id
        [HttpGet]
        [Route("GetFeedbackById/{id:Guid}")]
        public async Task<FeedBackResponseDTO> GetFeedbackById(Guid id)
        {
            var FeedbackResult = await _feedbackService.GetFeedbackById(id);
            var FeedbackDtoResult = _mapper.Map<FeedBackResponseDTO>(FeedbackResult);
            return FeedbackDtoResult;
        }

        //-->Delete Feedback
        [HttpDelete]
        [Route("DeleteFeedback/")]
        public async Task<IActionResult> DeleteFeedback(Guid id)
        {
            var FeedbackResult = await _feedbackService.DeleteFeedback(id);
            var FeedbackDtoResult = _mapper.Map<FeedBackResponseDTO>(FeedbackResult);
            return Ok(new
            {
                Data = FeedbackDtoResult,
                Message = "Feedback Deleted!"
            });
        }
    }
}