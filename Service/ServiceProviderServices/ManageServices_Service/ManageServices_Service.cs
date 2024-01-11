using imc_web_api.Dtos.AdminDtos.HCPDtos;
using imc_web_api.Models;
using imc_web_api.Service.ServiceProviderService.ManageServices_Service;

namespace imc_web_api.Service.ServiceProviderService.ManageServices
{
    public class ManageServices_Service : IManageServices_Service
    {
        public Task<service> AddService(service ServiceInputRequest)
        {
            throw new NotImplementedException();
        }

        public Task<service> DeleteService(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<service> GetServiceById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<service>> GetServices()
        {
            throw new NotImplementedException();
        }

        public Task<service> UpdateService(Guid id, service ServiceInputRequest)
        {
            throw new NotImplementedException();
        }
    }
}
