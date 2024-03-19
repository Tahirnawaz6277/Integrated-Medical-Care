using imc_web_api.Models;

namespace imc_web_api.Service.ServiceProviderService.ManageServices_Service
{
    public interface IManageService
    {
        Task<service> AddService(service ServiceInputRequest, Guid CurrentUserId);

        Task<service> DeleteService(Guid id);

        Task<service?> UpdateService(Guid id, service ServiceInputRequest);

        Task<service?> GetServiceById(Guid id);

        Task<List<service>> GetServices();
    }
}