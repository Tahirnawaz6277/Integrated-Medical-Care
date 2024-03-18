using imc_web_api.Dtos.AuthDtos;
using imc_web_api.Models;

namespace imc_web_api.Service.AdminServices.ManageAccountServices
{
    public interface IManageAccountService
    {
        Task<List<user>> GetUsers(string filterOn, string filterQuery, int pageNumber = 1, int pageSize = 100);
        Task<user?> GetUserById(Guid id);
        Task<user> AddUser(RegisterRequestDTO UserInputReguest);
        Task<user?> DeleteUser(Guid id);
        Task<user?> UpdateUser(Guid id, RegisterRequestDTO UserInputReguest);

    }
}
