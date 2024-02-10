using imc_web_api.Models;

namespace imc_web_api.Service.AdminServices.ManageOrderServices
{
    public interface IManageOrderService
    {
        Task<List<order>> GetOrders();

        Task<order?> GetOrderById(Guid id);

        Task<order> AddOrder(order UserInputReguest, string CurrentUserId);

        Task<order?> DeleteOrder(Guid id);

        Task<order?> UpdateOrder(Guid id, order UserInputReguest);
    }
}