using imc_web_api.Models;

namespace imc_web_api.Service.ServiceProviderService.ManageServices_Service
{
    public interface IManageService
    {
        Task<pharmacyambulanceservice> AddService(pharmacyambulanceservice ServiceInputRequest, Guid CurrentUserId);

        Task<pharmacyambulanceservice> DeleteService(Guid id);

        Task<pharmacyambulanceservice?> UpdateService(Guid id, pharmacyambulanceservice ServiceInputRequest);

        Task<pharmacyambulanceservice?> GetServiceById(Guid id);

        Task<List<pharmacyambulanceservice>> GetServices();
    }
}