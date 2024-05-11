using System.Security.Claims;
using AutoMapper;
using imc_web_api.Dtos.AdminDtos.ExpenseDtos;
using imc_web_api.Models;
using imc_web_api.Service.AdminServices.ManageExpenseServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace imc_web_api.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class ManageExpenseController : ControllerBase
    {
        private readonly IManageExpenseService _manageExpenseService;

        private readonly IMapper _mapper;

        public ManageExpenseController(IManageExpenseService manageExpenseService, IMapper mapper)
        {
            _manageExpenseService = manageExpenseService;
            _mapper = mapper;
        }

        // POST Expense
        [HttpPost]
        [Route("AddExpense")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddExpense([FromBody] ExpenseRequestDto ExpenseRequest)
        {
            try
            {
                if (ExpenseRequest == null)
                {
                    return BadRequest(ModelState);
                }



                var Expense_Model = _mapper.Map<Expense>(ExpenseRequest);
                var Expense_Result = await _manageExpenseService.AddExpenseAsync(Expense_Model );

                var Result = _mapper.Map<ExpenseResponseDto>(Expense_Result);

                return Ok(new
                {
                    success = true,
                    Message = "Expense Added Successfully!",
                    Data = Result
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

        // GET Expenses
        [HttpGet]
        [Route("GetExpenses")]
        public async Task<IActionResult> GetExpenses()
        {
            try
            {
                var expenses = await _manageExpenseService.GetExpensesAsync();

                var Expense_Result = _mapper.Map<List<ExpenseResponseDto>>(expenses);

                return Ok(new
                {
                    Success = true,
                    Data = Expense_Result
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

        // GET Expense By Id
        [HttpGet]
        [Route("GetExpenseById/{id:Guid}")]
        public async Task<IActionResult> GetExpenseById(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest("Id Field is Required!");
                }
                var expense = await _manageExpenseService.GetExpenseByIdAsync(id);

                var Result = _mapper.Map<ExpenseResponseDto>(expense);

                return Ok(new
                {
                    Success = true,
                    Data = Result
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

        // DELETE Expense
        [HttpDelete]
        [Route("DeleteExpense/{id:Guid}")]
        public async Task<IActionResult> DeleteExpense(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest("Id Field is Required!");
                }

                var Result = await _manageExpenseService.DeleteExpenseAsync(id);

                return Ok(new
                {
                    Success = true,
                    Message = "Expense Deleted Successfully!"
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

        // Update Expense
        [HttpPut]
        [Route("UpdateExpense/{id:Guid}")]
        public async Task<IActionResult> UpdateExpense(Guid id, ExpenseRequestDto ExpenseRequest)
        {
            try
            {
                if (ExpenseRequest == null || id == Guid.Empty)
                {
                    return BadRequest("Input Field is Required ");
                }

                var Expense_Model = _mapper.Map<Expense>(ExpenseRequest);

                var Expense_Result = await _manageExpenseService.UpdateExpenseAsync(id, Expense_Model);

                if (Expense_Result == null)
                {
                    return NotFound("Record Not Found!");
                }
                var Result = _mapper.Map<ExpenseResponseDto>(Expense_Result);
                return Ok(new
                {
                    success = true,
                    Message = "Expense Record Updated!",
                    Data = Result
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