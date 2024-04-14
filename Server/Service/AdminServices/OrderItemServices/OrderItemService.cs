using imc_web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace imc_web_api.Service.AdminServices.OrderItemServices
{
    public class OrderItemService : IOrderItemService
    {
        public ImcDbContext _ImcDbContext;

        public OrderItemService(ImcDbContext imcDbContext)
        {
            _ImcDbContext = imcDbContext;
        }

        public async Task<orderItem> AddOrderItem(orderItem UserInputReguest)
        {
            await _ImcDbContext.OrderItems.AddAsync(UserInputReguest);
            _ImcDbContext.SaveChanges();
            return UserInputReguest;
        }

        public async Task<orderItem?> DeleteOrderItem(Guid id)
        {
            var OrderItem = await _ImcDbContext.OrderItems.FirstOrDefaultAsync(o => o.Id == id);

            if (OrderItem is null)
            {
                return null;
            }


            _ImcDbContext.OrderItems.Remove(OrderItem);
            _ImcDbContext.SaveChanges();

            return OrderItem;
        }

        public async Task<orderItem?> GetOrderItemById(Guid id)
        {
            return await _ImcDbContext.OrderItems.Include(o => o.Order).Include(o => o.Service).FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<List<orderItem>> GetOrderItems()
        {
            return await _ImcDbContext.OrderItems.Include(o => o.Order).Include(o => o.Service).ToListAsync();
        }

        public Task<orderItem?> UpdateOrderItem(Guid id, orderItem UserInputReguest)
        {
            throw new NotImplementedException();
        }
    }
}