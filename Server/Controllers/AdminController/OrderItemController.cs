using AutoMapper;
using imc_web_api.Dtos.AdminDtos.Order_ItemsDtos;
using imc_web_api.Models;
using imc_web_api.Service.AdminServices.OrderItemServices;
using Microsoft.AspNetCore.Mvc;

namespace imc_web_api.Controllers.AdminController
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        public IOrderItemService _OrderItemService { get; }
        public readonly IMapper _mapper;

        public OrderItemController(IOrderItemService orderItemService, IMapper mapper)
        {
            _OrderItemService = orderItemService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("OrderItem")]
        public async Task<IActionResult> CreateOrderItem([FromBody] OrderItemRequestDto OrderItem_Input_Request)
        {
            try
            {
                if (OrderItem_Input_Request is null)
                {
                    return BadRequest("Input Field is Required!");
                }

                var OrderItem_Model = _mapper.Map<orderItem>(OrderItem_Input_Request);

                var Added_OrderItem = await _OrderItemService.AddOrderItem(OrderItem_Model);

                var OrderItem_Dto_Result = _mapper.Map<OrderItemResponseDto>(Added_OrderItem);
                return Ok(new
                {
                    Success = true,
                    Message = "Order Placed Successfully!",
                    Data = OrderItem_Dto_Result
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

        [HttpGet]
        [Route("OrderItem")]
        public async Task<IActionResult> GetOrderItems()
        {
            try
            {
                var orderItems = await _OrderItemService.GetOrderItems();

                var orderItems_Mapped = _mapper.Map<List<OrderItemResponseDto>>(orderItems);

                return Ok(new
                {
                    Success = true,
                    Data = orderItems_Mapped
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

        [HttpGet]
        [Route("OrderItemById/{id:Guid}")]
        public async Task<IActionResult> GetOrderItemById(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest("Id Field is Required!");
                }
                var orderItem = await _OrderItemService.GetOrderItemById(id);

                var orderItems_Mapped = _mapper.Map<OrderItemResponseDto>(orderItem);

                return Ok(new
                {
                    Success = true,
                    Data = orderItems_Mapped
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

        [HttpDelete]
        [Route("OrderItemById/{id:Guid}")]
        public async Task<IActionResult> DeleteOrderItemById(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest("Id Field is Required!");
                }

                var orderItem = await _OrderItemService.DeleteOrderItem(id);

                if(orderItem is null)
                {
                    return NotFound(id);
                }

                return Ok(new
                {
                    Success = true,
                    Message = "Order Deleted Successfully!"
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
    }
}