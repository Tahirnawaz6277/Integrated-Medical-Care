using imc_web_api.Dtos.HCPDtos;
using imc_web_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace imc_web_api.Service.AdminServices.ManageHCPServices
{
    public interface IManageHCPService
    {
        public Task<IActionResult> AddProvider(HCPRequestDTO UserInputReges);
        Task<serviceprovidertype> DeleteProvider(Guid id);
        public Task UpdateProvider();
        Task<serviceprovidertype> GetProviderById(Guid id);
        public Task<List<serviceprovidertype>> GetProviders();

    }
}
