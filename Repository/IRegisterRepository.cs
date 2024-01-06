using imc_web_api.Dtos;

namespace imc_web_api.Repository
{
    public interface IRegisterRepository
    {
        Task AddUser(RegisterRequestDTO userData);
    }
}
