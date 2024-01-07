using imc_web_api.Dtos;
using imc_web_api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace imc_web_api.Service.AdminServices.ManageAccountServices
{
    public interface IManageAccountService
    {
        Task<List<user>> GetUsers();
        Task<user> GetUserById(Guid id);
        Task<user> AddUser(RegisterRequestDTO UserInputReguest);
        Task<user> DeleteUser(Guid id);
        Task<user> UpdateUser(Guid id, RegisterRequestDTO UserInputReguest);

    }
}
