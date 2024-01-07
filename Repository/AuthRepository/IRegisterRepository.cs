using imc_web_api.Dtos;

namespace imc_web_api.Repository.AuthRepository
{
    public interface IRegisterRepository
    {
        Task AddUser(RegisterRequestDTO userData);
    }
}
