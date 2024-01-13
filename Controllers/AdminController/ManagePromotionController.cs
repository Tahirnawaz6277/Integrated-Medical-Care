using AutoMapper;
using imc_web_api.Dtos.AdminDtos.PromotionDtos;
using imc_web_api.Models;
using imc_web_api.Service.AdminServices.ManagePromotionServices;
using Microsoft.AspNetCore.Mvc;

namespace imc_web_api.Controllers.AdminController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagePromotionController : ControllerBase
    {
        private readonly IManagePromotionService _managePromotionService;
        private readonly IMapper _mapper;

        public ManagePromotionController(IManagePromotionService managePromotionService, IMapper mapper)
        {
            _managePromotionService = managePromotionService;
            _mapper = mapper;
        }

        //--> Add Promotion
        [HttpPost]
        [Route("AddPromotion")]
        public async Task<IActionResult> AddPromotion([FromBody] PromotionRequestDTO Promotion_Input_Request)
        {
            var Promotion_Model = _mapper.Map<promotion>(Promotion_Input_Request);
            var Promotion_Result = await _managePromotionService.AddPromotion(Promotion_Model);

            var PromotionDto_Result = _mapper.Map<PromotionResponseDTO>(Promotion_Result);

            return Ok(new
            {
                Data = PromotionDto_Result,
                Message = "Promotion Send!"
            });
        }

        //--> Update Promotion
        [HttpPut]
        [Route("UpdatePromotion/{id:Guid}")]
        public async Task<IActionResult> UpdatePromotion(Guid id, [FromBody] PromotionRequestDTO PromotionRequestDTO)
        {
            var Promotion_Model = _mapper.Map<promotion>(PromotionRequestDTO);
            var Promotion_Result = await _managePromotionService.UpdatePromotion(id, Promotion_Model);

            var PromotionDto_Result = _mapper.Map<PromotionResponseDTO>(Promotion_Result);

            return Ok(new
            {
                Data = PromotionDto_Result,
                Message = "Promotion Updated!"
            });
        }

        //--> Get Promotions
        [HttpGet]
        [Route("GetPromotions")]
        public async Task<List<PromotionResponseDTO>> GetPromotions()
        {
            var Promotion_Result = await _managePromotionService.GetPromotions();

            var PromotionDto_Result = _mapper.Map<List<PromotionResponseDTO>>(Promotion_Result);

            return PromotionDto_Result;
        }

        //--> Get Promotion By Id
        [HttpGet]
        [Route("GetPromotionById/{id:Guid}")]
        public async Task<PromotionResponseDTO> GetPromotionById(Guid id)
        {
            var Promotion_Result = await _managePromotionService.GetPromotionById(id);

            var PromotionDto_Result = _mapper.Map<PromotionResponseDTO>(Promotion_Result);

            return PromotionDto_Result;
        }

        //--> Delete Promotion
        [HttpDelete]
        [Route("DeletePromotion/{id:Guid}")]
        public async Task<IActionResult> DeletePromotion(Guid id)
        {
            var Promotion_Result = await _managePromotionService.DeletePromotion(id);

            var PromotionDto_Result = _mapper.Map<PromotionResponseDTO>(Promotion_Result);

            return Ok(new
            {
                Message = "Promotion Deleted!",
                Data = PromotionDto_Result
            }) ;
        }
    }
}