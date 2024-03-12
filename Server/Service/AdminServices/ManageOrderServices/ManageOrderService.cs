using imc_web_api.Models;
using imc_web_api.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace imc_web_api.Service.AdminServices.ManageOrderServices
{
    public class ManageOrderService : IManageOrderService
    {
        public ImcDbContext _ImcDbContext;

        public ManageOrderService(ImcDbContext imcDbContext)
        {
            _ImcDbContext = imcDbContext;
        }

        //-->  Place/Create Order
        public async Task<order> AddOrder(order UserInputReguest, string CurrentUserId)
        {
            UserInputReguest.OrderByUserId = CurrentUserId;
            UserInputReguest.orderStatus = OrderStatusEnum.OrderStatus.Pending;
            UserInputReguest.IsDeleted = false;
            await _ImcDbContext.Orders.AddAsync(UserInputReguest);
            _ImcDbContext.SaveChanges();

            return UserInputReguest;
        }

        //-->  Delete Order
        public async Task<order?> DeleteOrder(Guid id)
        {
            var Existing_Order = await _ImcDbContext.Orders

                .FirstOrDefaultAsync(o => o.Id == id);

            if (Existing_Order == null)
            {
                return null;
            }

            _ImcDbContext.Remove(Existing_Order);
            await _ImcDbContext.SaveChangesAsync();
            return Existing_Order;
        }

        //-->  Get Order By Id
        public async Task<order?> GetOrderById(Guid id)
        {
            return await _ImcDbContext.Orders
                .Include(o => o.OrderBy)
                .Include(o => o.Service).FirstOrDefaultAsync(o => o.Id == id);
        }

        //-->  Get Orders
        public async Task<List<order>> GetOrders()
        {
            return await _ImcDbContext.Orders
                .Include(o => o.OrderBy)
                .Include(o => o.Service).ToListAsync();
        }

        //-->  Update Order
        public async Task<order?> UpdateOrder(Guid id, order UserInputReguest)
        {
            var Existing_Order = await _ImcDbContext.Orders.FirstOrDefaultAsync(o => o.Id == id);

            if (Existing_Order != null)
            {
                Existing_Order.Contact = UserInputReguest.Contact;

                Existing_Order.Address = UserInputReguest.Address;
                Existing_Order.OrderQuantity = UserInputReguest.OrderQuantity;
                Existing_Order.Amount = UserInputReguest.Amount;
                Existing_Order.PaymentMode = UserInputReguest.PaymentMode;
                Existing_Order.IsDeleted = UserInputReguest.IsDeleted;

                _ImcDbContext.SaveChanges();
                return Existing_Order;
            }
            return null;
        }
    }
}