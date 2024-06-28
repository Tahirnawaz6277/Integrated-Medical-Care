using AutoMapper;
using imc_web_api.Dtos.AdminDtos.InventoryDtos;
using imc_web_api.Models;
using imc_web_api.Service.AdminServices.ManageInventoryServices;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace imc_web_api.Controllers.AdminController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageInventoryController : ControllerBase
    {
        private readonly IManageInventoryService _manageInventoryService;

        private readonly IMapper _mapper;

        public ManageInventoryController(IManageInventoryService manageInventoryService, IMapper mapper)
        {
            _manageInventoryService = manageInventoryService;
            _mapper = mapper;
        }

        // GET Inventories
        [HttpGet]
        [Route("GetInventories")]
        public async Task<IActionResult> GetInventories()
        {
            try
            {
                var INV_Items = await _manageInventoryService.GetInventoriesAsync();

                var INV_Result = _mapper.Map<List<InventoryResponseDto>>(INV_Items);

                return Ok(new
                {
                    Success = true,
                    Data = INV_Result
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

        // GET Inventory BY ID
        [HttpGet]
        [Route("GetInventoryById/{id:Guid}")]
        public async Task<IActionResult> GetInventoryById(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest("Id Field is Required!");
                }
                var INV_Items = await _manageInventoryService.GetInventoryByIdAsync(id);

                var INV_Result = _mapper.Map<InventoryResponseDto>(INV_Items);

                return Ok(new
                {
                    Success = true,
                    Data = INV_Result
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

        // POST Inventory
        [HttpPost]
        [Route("AddInventory")]
        public async Task<IActionResult> AddInventory([FromBody] InventoryRequestDto inventoryRequest)
        {
            try
            {
                if (inventoryRequest == null)
                {
                    return BadRequest(ModelState);
                }
                var INV_Model = _mapper.Map<Inventory>(inventoryRequest);
                var INV_Result = await _manageInventoryService.AddInventoryAsync(INV_Model);

                var Result = _mapper.Map<InventoryResponseDto>(INV_Result);

                return Ok(new
                {
                    success = true,
                    Message = "Item Added Successfully!",
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

        // DELETE Inventory
        [HttpDelete]
        [Route("DeleteInventory/{id:Guid}")]
        public async Task<IActionResult> DeleteInventory(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest("Id Field is Required!");
                }

                var orderItem = await _manageInventoryService.DeleteInventoryAsync(id);

                return Ok(new
                {
                    Success = true,
                    Message = "Item Deleted Successfully!"
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

        // Update Inventory
        [HttpPut]
        [Route("UpdateInventory/{id:Guid}")]
        public async Task<IActionResult> UpdateInventory(Guid id, InventoryRequestDto inventoryRequest)
        {
            try
            {
                if (inventoryRequest == null || id == Guid.Empty)
                {
                    return BadRequest("Input Field is Required ");
                }

                var INV_Model = _mapper.Map<Inventory>(inventoryRequest);

                var INV_Result = await _manageInventoryService.UpdateInventoryAsync(id, INV_Model);

                if (INV_Result == null)
                {
                    return NotFound("Record Not Found!");
                }
                var result = _mapper.Map<InventoryResponseDto>(INV_Result);
                return Ok(new
                {
                    success = true,
                    Message = "Health care Record Updated!",
                    Data = result
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




        [HttpPatch]
		[Route("UpdateIventory/{id:Guid}")]
		public async Task<IActionResult> UpdateSingleInventory(Guid id, [FromBody] JsonPatchDocument<Inventory> jsonPatchDocument)
        {
		

            try
            {
				if (jsonPatchDocument == null || id == Guid.Empty)
				{
					return BadRequest();
				}

				var Inventory = await _manageInventoryService.UpdateSingleInventoryAsync(id, jsonPatchDocument);

				if (Inventory == null)
				{
					return NotFound("Record Not Found!");
				}

				return Ok(new
				{
					Success = true,
					Message = "Inventory Updated!",
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