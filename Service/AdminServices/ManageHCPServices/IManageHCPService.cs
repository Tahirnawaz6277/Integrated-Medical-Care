using imc_web_api.Dtos.HCPDtos;
using imc_web_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace imc_web_api.Service.AdminServices.ManageHCPServices
{
    public interface IManageHCPService
    {
        public Task<IActionResult> AddProvider(HCPRequestDTO UserInputReges);
        public Task DeleteProvider();
        public Task UpdateProvider();
        public Task<List<serviceprovidertype>> GetProviders();

    }
}
