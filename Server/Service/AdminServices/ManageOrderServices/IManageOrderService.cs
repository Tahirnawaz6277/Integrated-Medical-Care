using imc_web_api.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace imc_web_api.Service.AdminServices.ManageOrderServices
{
    public interface IManageOrderService
    {
        Task<List<order>> GetOrders(string CurrentUserId , string userRole);

        Task<order?> GetOrderById(Guid id);

        Task<order> AddOrder(order UserInputReguest, string CurrentUserId , string loggednInUserRole);

        Task<order?> DeleteOrder(Guid id , string userRole);

        Task<order?> UpdateOrder(Guid id, JsonPatchDocument patch);
    }
}