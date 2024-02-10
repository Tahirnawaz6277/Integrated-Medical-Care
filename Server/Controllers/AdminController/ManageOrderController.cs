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
            try
            {
                var CurrentUserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (string.IsNullOrEmpty(CurrentUserId))
                {
                    return Unauthorized("User is not authenticated.");
                }

                if (Order_Input_Request == null)
                {
                    return BadRequest("Input Field is Required!");
                }
                var Order_Model = _mapper.Map<order>(Order_Input_Request);

                var Order_Model_Result = await _manageOrderService.AddOrder(Order_Model, CurrentUserId);

                var Order_DTO_Result = _mapper.Map<OrderResponseDTO>(Order_Model_Result);

                return Ok(new
                {
                    Success = true,
                    Message = "Order Placed Successfully!",
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

        //-->  Get Orders
        [HttpGet]
        [Route("GetOrders")]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                var Order_Model_Result = await _manageOrderService.GetOrders();
                var Order_DTO_Result = _mapper.Map<List<OrderResponseDTO>>(Order_Model_Result);

                return Ok(new
                {
                    Success = true,
                    Data = Order_DTO_Result
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

        //-->  Get Order By Id
        [HttpGet]
        [Route("GetOrder/{id:Guid}")]
        public async Task<IActionResult> GetOrder(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest("Id Field is Required!");
                }
                var Order_Model_Result = await _manageOrderService.GetOrderById(id);
                var Order_DTO_Result = _mapper.Map<OrderResponseDTO>(Order_Model_Result);
                return Ok(new
                {
                    Success = true,
                    Data = Order_DTO_Result
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

        //-->  Update Order
        [HttpPut]
        [Route("UpdateOrder/{id:Guid}")]
        public async Task<IActionResult> UpdateOrder(Guid id, [FromBody] OrderRequestDTO Order_Input_Request)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest("Id Field is Required!");
                }
                var Order_Model = _mapper.Map<order>(Order_Input_Request);
                var Order_Model_Result = await _manageOrderService.UpdateOrder(id, Order_Model);

                if (Order_Model_Result == null)
                {
                    return NotFound("Record Not Found!");
                }

                var Order_DTO_Result = _mapper.Map<OrderResponseDTO>(Order_Model_Result);
                return Ok(new
                {
                    Success = true,
                    Message = "Order Updated!"

,
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

        //-->  Deleted Order
        [HttpDelete]
        [Route("DeleteOrder/{id:Guid}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest("Id Field is Required!");
                }
                var Order_Model_Result = await _manageOrderService.DeleteOrder(id);

                if (Order_Model_Result == null)
                {
                    return NotFound("Record Not Found!");
                }
                var Order_DTO_Result = _mapper.Map<OrderResponseDTO>(Order_Model_Result);

                return Ok(new
                {
                    Success = true,
                    Message = "Order Deleted Successfully!",
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