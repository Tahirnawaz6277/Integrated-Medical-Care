using imc_web_api.Dtos.AdminDtos.HCPDtos;
using Microsoft.AspNetCore.Mvc;

namespace imc_web_api.Controllers.AdminController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageFeedBackController : ControllerBase
    {
        private readonly ImcDbContext _imcDbContext;

        public ManageFeedBackController(ImcDbContext imcDbContext)
        {
            _imcDbContext = imcDbContext;
        }

        //-->Add Feedback
        [HttpPost]
        [Route("AddFeedback")]
        public async Task<IActionResult> AddFeedback()
        {
            return null;
        }

        //-->Update Feedback
        [HttpPut]
        [Route("UpdateFeedback/{id:Guid}")]
        public async Task<IActionResult> UpdateFeedback()
        {
            return null;
        }

        //-->GetAll Feedback
        [HttpGet]
        [Route("GetFeedbacks")]
        public Task<IActionResult> GetFeedbacks()
        {
            return null;
        }

        // -->Get Feedback By Id
        [HttpGet]
        [Route("GetFeedbackById/{id:Guid}")]
        public async Task<HCPResponseDTO> GetFeedbackById()
        {
            return null;
        }

        //-->Delete Feedback
        [HttpDelete]
        [Route("DeleteHCP")]
        public async Task<HCPResponseDTO> DeleteHCP()
        {
            return null;
        }
    }
}