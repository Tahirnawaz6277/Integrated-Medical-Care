using imc_web_api.Models;

namespace imc_web_api.Service.AdminServices.OrderItemServices
{
    public interface IOrderItemService
    {

        Task<List<orderItem>> GetOrderItems();

        Task<orderItem?> GetOrderItemById(Guid id);

        Task<orderItem> AddOrderItem(orderItem UserInputReguest);

        Task<orderItem?> DeleteOrderItem(Guid id);

        Task<orderItem?> UpdateOrderItem(Guid id, orderItem UserInputReguest);

    }
}
