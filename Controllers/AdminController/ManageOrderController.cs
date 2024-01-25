using AutoMapper;
using imc_web_api.Dtos.AdminDtos.OrderDtos;
using imc_web_api.Models;
using imc_web_api.Service.AdminServices.ManageOrderServices;
using Microsoft.AspNetCore.Mvc;

namespace imc_web_api.Controllers.AdminController
{
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

        // POST ORDER
        [HttpPost]
        [Route("AddOrder")]
        public async Task<IActionResult> AddOrder([FromBody] OrderRequestDTO Order_Input_Request)
        {
            var Order_Model = _mapper.Map<order>(Order_Input_Request);

            var Order_Model_Result = await _manageOrderService.AddOrder(Order_Model);

            var Order_DTO_Result = _mapper.Map<OrderResponseDTO>(Order_Model_Result);

            return Ok(new
            {
                Message = "Order Placed!",
                Data = Order_DTO_Result,
            });
        }

        // GET ORDERS
        [HttpGet]
        [Route("GetOrders")]
        public async Task<List<OrderResponseDTO>> GetOrders()
        {
            var Order_Model_Result = await _manageOrderService.GetOrders();
            var Order_DTO_Result = _mapper.Map<List<OrderResponseDTO>>(Order_Model_Result);
            return Order_DTO_Result;
        }

        // GET ORDER BY ID
        [HttpGet]
        [Route("GetOrder/{id:Guid}")]
        public async Task<order> GetOrder(Guid id)
        {
            //var Order_Model_Result = await _manageOrderService.GetOrderById(id);
            //var Order_DTO_Result = _mapper.Map<List<OrderResponseDTO>>(Order_Model_Result);
            //return Order_DTO_Result;
            return null;
        }

        // PUT ORDER
        [HttpPut]
        [Route("UpdateOrder/{id:Guid}")]
        public async Task<IActionResult> UpdateOrder(Guid id, [FromBody] order value)
        {
            return null;
        }

        // DELETE  ORDER
        [HttpDelete]
        [Route("DeleteOrder/{id:Guid}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            return null;
        }
    }
}