using imc_web_api.Dtos.AdminDtos.HCPDtos;

using imc_web_api.Models;

namespace imc_web_api.Service.AdminServices.ManageHCPServices
{
    public interface IManageHCPService
    {
        Task<serviceprovidertype> AddProvider(serviceprovidertype UserInputReguest);

        Task<serviceprovidertype?> DeleteProvider(Guid id);

        Task<serviceprovidertype?> UpdateProvider(Guid id, HCPRequestDTO InputRequestDTO);

        Task<user?> GetProviderById(Guid id);

        Task<List<user>> GetProviders();
    }
}