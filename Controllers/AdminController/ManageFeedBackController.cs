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

        //-->Add Feedback
        [HttpPost]
        [Route("AddFeedback")]
        public async Task<IActionResult> CreateFeedback([FromBody] FeedBackRequesrDTO InputRequest)
        {
            var fm = _mapper.Map<feedback>(InputRequest);
            var fmr = _feedbackService.AddFeedback(fm);
            var fdto = _mapper.Map<feedback>(fmr);

            return Ok(new
            {
                Data = fdto,
                Message = "Feedback added successfully:"
            });
        }

        //-->Update Feedback
        [HttpPut]
        [Route("UpdateFeedback/{id:Guid}")]
        public async Task<IActionResult> UpdateFeedback(Guid id, FeedBackRequesrDTO InputRequest)
        {
            if (InputRequest != null)
            {
                var fmodel = _mapper.Map<feedback>(InputRequest);
                var fdto = _mapper.Map<feedback>(fmodel);
                return Ok(new
                {
                    Data = fdto,
                    Message = "Feedback Updated Successfully:"
                }) ;

            }
            else
            {
                return BadRequest();
            }
        }

        //-->GetAll Feedback
        [HttpGet]
        [Route("GetFeedbacks")]
        public async Task<IActionResult> GetFeedbacks()
        {
            var af =await _feedbackService.GetFeedbacks();
            if (af == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(new
                {
                    Data = af,
                    Message = "Retreiving all feedback successfully:"
                }); ;
            }
        }

        // -->Get Feedback By Id
        [HttpGet]
        [Route("GetFeedbackById/{id:Guid}")]
        public async Task<FeedBackResponseDTO> GetFeedbackById(Guid id)
        {
            var fi = await _feedbackService.GetFeedbackById(id);
            var fidto = _mapper.Map<FeedBackResponseDTO>(fi);
            return fidto;
        }

        //-->Delete Feedback
        [HttpDelete]
        [Route("DeleteHCP")]
        public async Task<FeedBackResponseDTO> DeleteFeedback(Guid id)
        {
            var df = await _feedbackService.DeleteFeedback(id);
            var dfmodel = _mapper.Map<FeedBackResponseDTO>(df);
            return dfmodel;
        }
    }
}