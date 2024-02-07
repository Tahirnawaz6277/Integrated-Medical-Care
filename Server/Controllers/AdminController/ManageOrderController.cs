using System.Security.Claims;
using AutoMapper;
using imc_web_api.Dtos.AdminDtos.OrderDtos;
using imc_web_api.Models;
using imc_web_api.Service.AdminServices.ManageOrderServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace imc_web_api.Controllers.AdminController
{
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class ManageOrderController : ControllerBase
    {
        public ImcDbContext _ImcDbContext;
        private readonly IManageOrderService _manageOrderService;
        private readonly IMapper _mapper;

        public ManageOrderController(ImcDbContext imcDbContext, IManageOrderService manageOrderService, IMapper mapper)
        {
            _ImcDbContext = imcDbContext;
            _manageOrderService = manageOrderService;
            _mapper = mapper;
        }

        //-->  Place/Create Order

        [HttpPost]
        [Route("AddOrder")]
        //[Authorize(Roles = "Admin,Customer")]
        public async Task<IActionResult> AddOrder([FromBody] OrderRequestDTO Order_Input_Request)
        {
            var CurrentUserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var Order_Model = _mapper.Map<order>(Order_Input_Request);

            var Order_Model_Result = await _manageOrderService.AddOrder(Order_Model, CurrentUserId);

            var Order_DTO_Result = _mapper.Map<OrderResponseDTO>(Order_Model_Result);

            return Ok(new
            {
                Message = "Order Placed!",
                Data = Order_DTO_Result,
            });
        }

        //-->  Get Orders
        [HttpGet]
        [Route("GetOrders")]
        //[Authorize(Roles = "Admin , Customer")]
        public async Task<IActionResult> GetOrders()
        {
            var Order_Model_Result = await _manageOrderService.GetOrders();
            var Order_DTO_Result = _mapper.Map<List<OrderResponseDTO>>(Order_Model_Result);

            return Ok(new
            {
                success = true,
                data = Order_DTO_Result
            });
        }

        //-->  Get Order By Id
        [HttpGet]
        [Route("GetOrder/{id:Guid}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetOrder(Guid id)
        {
            var Order_Model_Result = await _manageOrderService.GetOrderById(id);
            var Order_DTO_Result = _mapper.Map<OrderResponseDTO>(Order_Model_Result);
            return Ok(new
            {
                success = true,
                data = Order_DTO_Result
            });
        }

        //-->  Update Order
        [HttpPut]
        [Route("UpdateOrder/{id:Guid}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateOrder(Guid id, [FromBody] OrderRequestDTO Order_Input_Request)
        {
            var Order_Model = _mapper.Map<order>(Order_Input_Request);
            var Order_Model_Result = await _manageOrderService.UpdateOrder(id, Order_Model);
            var Order_DTO_Result = _mapper.Map<OrderResponseDTO>(Order_Model_Result);
            return Ok(new
            {
                Message = "Order Updated!",
                Data = Order_DTO_Result,

                success = true,
            });
        }

        //-->  Deleted Order
        [HttpDelete]
        [Route("DeleteOrder/{id:Guid}")]
        //[Authorize(Roles = "Admin,Customer")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            var Order_Model_Result = await _manageOrderService.DeleteOrder(id);
            var Order_DTO_Result = _mapper.Map<OrderResponseDTO>(Order_Model_Result);

            return Ok(new
            {
                Message = "Order Deleted Successfully!",
                Data = Order_DTO_Result,

                success = true,
            });
        }
    }
}