﻿using imc_web_api.Dtos.AuthDtos;
using imc_web_api.Models;

namespace imc_web_api.Service.AdminServices.ManageAccountServices
{
    public interface IManageAccountService
    {
        Task<List<user>> GetUsers(string? filterOn =null, string? filterQuery =null);
        Task<user?> GetUserById(Guid id);
        Task<user> AddUser(RegisterRequestDTO UserInputReguest);
        Task<user?> DeleteUser(Guid id);
        Task<user?> UpdateUser(Guid id, RegisterRequestDTO UserInputReguest);

    }
}
