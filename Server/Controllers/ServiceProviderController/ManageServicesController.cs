﻿using System.Security.Claims;
using AutoMapper;
using imc_web_api.Dtos.ServiceProviderDtos;
using imc_web_api.Models;
using imc_web_api.Service.ServiceProviderService.ManageServices_Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace imc_web_api.Controllers.ServiceProviderController
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class ManageServicesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IManageService _manageServices;

        public ManageServicesController(IMapper mapper, IManageService manageServices)
        {
            _mapper = mapper;
            _manageServices = manageServices;
        }

        //--> Add Service

        [HttpPost]
        [Route("AddService")]
        [Authorize(Roles = "Admin,ServiceProvider")]
        public async Task<IActionResult> AddService([FromBody] ServiceRequestDTO ServiceInputRequest)
        {
            try
            {
                if (ServiceInputRequest == null)
                {
                    return BadRequest(ModelState);
                }

                var CurrentUserId = Guid.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

                if (string.IsNullOrEmpty(CurrentUserId.ToString()))
                {
                    return Unauthorized("User is not authenticated.");
                }

                var ServiceModel = _mapper.Map<service>(ServiceInputRequest);
                var ServiceDtoResult = await _manageServices.AddService(ServiceModel, CurrentUserId);

                if (ServiceDtoResult == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Failed to add Service.");
                }
                var ServiceDto_Result = _mapper.Map<service>(ServiceDtoResult);
                return Ok(new
                {
                    Success = true,
                    Data = ServiceDto_Result,
                    Message = "Service Added Successfully!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    ErrorMessage = ex.Message,
                });
            }
        }

        //-->Update Service
        [HttpPut]
        [Route("UpdateService/{id:Guid}")]
        [Authorize(Roles = "Admin,ServiceProvider")]
        public async Task<IActionResult> UpdateService(Guid id, [FromBody] ServiceUpdateDto ServiceInputRequest)
        {
            try
            {
                var ServiceModel = _mapper.Map<service>(ServiceInputRequest);

                var UpdatedService = await _manageServices.UpdateService(id, ServiceModel);

                if (UpdatedService == null)
                {
                    return NotFound("Record Not Found!");
                }
                return Ok(new
                {
                    Success = true,
                    Data = UpdatedService,
                    Message = "Service Updated!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    ErrorMessage = ex.Message,
                });
            }
        }

        //-->GetAll Service
        [HttpGet]
        [Route("GetServices")]
        [Authorize(Roles = "Admin,ServiceProvider,Customer")]
        public async Task<IActionResult> GetServices()
        {
            try
            {
                // Get the current user's role claim
                var roleClaim = HttpContext.User.FindFirst(ClaimTypes.Role);

                if (roleClaim == null)
                {
                    return Unauthorized("Role claim not found for the current user.");
                }

                if (roleClaim.Value == "ServiceProvider")
                {
                    // Get the current user's role id
                    var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                    var ServiceModel = await _manageServices.GetServices(userId);
                    var ServiceDtoResult = _mapper.Map<List<ServiceResponseDTO>>(ServiceModel);

                    return Ok(new
                    {
                        Success = true,
                        Data = ServiceDtoResult,
                    });
                }
                else if (roleClaim.Value == "Admin" || roleClaim.Value == "Customer")
                {
                    // Call a service method to retrieve all services
                    var services = await _manageServices.GetServices();

                    // Map the service models to DTOs
                    var serviceDtoResult = _mapper.Map<List<ServiceResponseDTO>>(services);

                    return Ok(new
                    {
                        Success = true,
                        Data = serviceDtoResult,
                    });
                }
                // For other roles, return an unauthorized response
                else
                {
                    return Unauthorized("Unauthorized access.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    ErrorMessage = ex.Message,
                });
            }
        }

        // -->Get Service By Id
        [HttpGet]
        [Route("GetServiceById/{id:Guid}")]
        [Authorize(Roles = "Admin,ServiceProvider ,Customer")]
        public async Task<IActionResult> GetServiceById(Guid id)
        {
            try
            {
                var ServiceModel = await _manageServices.GetServiceById(id);
                var ServiceDtoResult = _mapper.Map<ServiceResponseDTO>(ServiceModel);

                return Ok(new
                {
                    Success = true,
                    Data = ServiceDtoResult,
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    ErrorMessage = ex.Message,
                });
            }
        }

        //-->Delete Service
        [HttpDelete]
        [Route("DeleteService")]
        [Authorize(Roles = "Admin,ServiceProvider")]
        public async Task<IActionResult> DeleteService(Guid id)
        {
            try
            {
                if (Guid.Empty == id)
                {
                    return BadRequest();
                }



                var DeleteService = await _manageServices.DeleteService(id);
                

                if (DeleteService == null)
                {
                    return NotFound();
                }

                return Ok(new
                {
                    Success = true,
                    Data = DeleteService,
                    Message = "Service Deleted Successfully!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    ErrorMessage = ex.InnerException.Message,
                });
            }
        }
    }
}