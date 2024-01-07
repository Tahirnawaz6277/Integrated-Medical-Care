﻿using imc_web_api.Models;
using imc_web_api.Service.AdminServices.ManageAccountServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace imc_web_api.Controllers.AdminController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageAcountController : ControllerBase
    {
        private readonly UserManager<user> _userManager;
        private readonly IManageAccountService _manageAccountService;

        public ManageAcountController(UserManager<user> userManager, IManageAccountService manageAccountService)
        {
            _userManager = userManager;
            _manageAccountService = manageAccountService;
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser()
        {
            return null;
        }

        [HttpGet]
        [Route("GetUsers")]
        public async Task<List<user>> GetUsers()
        {
            return await _manageAccountService.GetUsers();
        }

        [HttpGet]
        [Route("GetUserById/{id:Guid}")]
        public async Task<user> GetUserById(Guid id)
        {
            return await _manageAccountService.GetUserById(id);
        }

        [HttpPut]
        [Route("UpdateUser /{id:Guid}")]
        public async Task<IActionResult> UpdateUser(Guid id)
        {
            return null;
        }

        [HttpDelete]
        [Route("DeleteUser /{id:Guid}")]
        public async Task<user> DeleteUser(Guid id)
        {
            return await _manageAccountService.DeleteUser(id);
        }
    }
}