using imc_web_api.Models;

namespace imc_web_api.Service.AdminServices.ManageRevenueServices
{
    public interface IManageRevenueService
    {
        Task<List<Revenue>> GetRevenuesAsync();

        Task<Revenue?> GetRevenueByIdAsync(Guid id);

        Task<Revenue> AddRevenueAsync(Revenue revenue, string CurrentUserId);

        Task<Revenue?> DeleteRevenueAsync(Guid id);

        Task<Revenue?> UpdateRevenueAsync(Guid id, Revenue revenue);
    }
}