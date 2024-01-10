using imc_web_api.Dtos.HCPDtos;
using imc_web_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace imc_web_api.Service.AdminServices.ManageHCPServices
{
    public interface IManageHCPService
    {
        Task<IActionResult> AddProvider(HCPRequestDTO UserInputReges);

        Task<serviceprovidertype> DeleteProvider(Guid id);

        Task<serviceprovidertype> UpdateProvider(Guid id, HCPRequestDTO InputRequestDTO);

        Task<serviceprovidertype> GetProviderById(Guid id);

        Task<List<serviceprovidertype>> GetProviders();
    }
}