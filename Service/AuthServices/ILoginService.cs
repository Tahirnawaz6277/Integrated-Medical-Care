using imc_web_api.Dtos.AuthDtos;
using Microsoft.AspNetCore.Mvc;

namespace imc_web_api.Service.AuthService
{
    public interface ILoginService
    {
        Task<LoginResponseDTO> Login(LoginRequestDTO userData);
    }
}
