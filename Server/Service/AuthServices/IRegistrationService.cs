using imc_web_api.Controllers.AuthController;
using imc_web_api.Dtos.AuthDtos;
using imc_web_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace imc_web_api.Service.AuthService
{
    public interface IRegistrationService
    {
        Task<user> FindUserByEmail(string email);
        Task<user> AddUser(RegisterRequestDTO userData);
    }
}
