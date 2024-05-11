using imc_web_api.Models;
using imc_web_api.Models.Enums;
using Microsoft.AspNetCore.JsonPatch;
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
        public async Task<order> AddOrder(order UserInputReguest, string CurrentUserId, string loggednInUserRole)
        {
            bool isAdmin = loggednInUserRole == "Admin";

            UserInputReguest.OrderByUserId = CurrentUserId;

            UserInputReguest.orderStatus = OrderStatusEnum.OrderStatus.Pending;
            UserInputReguest.IsDeleted = false;
            UserInputReguest.Paid = UserInputReguest.Paid;
            UserInputReguest.IsTransferPayment = false;

            if (isAdmin)
            {
                UserInputReguest.OrderToUserId = UserInputReguest.OrderToUserId;
            }
            else
            {
                UserInputReguest.OrderToUserId = null;
            }

            await _ImcDbContext.Orders.AddAsync(UserInputReguest);
            _ImcDbContext.SaveChanges();

            return UserInputReguest;
        }

        //-->  Delete Order

        public async Task<order?> DeleteOrder(Guid id, string userRole)
        {
            var existingOrder = await _ImcDbContext.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (existingOrder == null)
            {
                return null;
            }

            if (userRole == "Admin")
            {
                _ImcDbContext.Remove(existingOrder);
            }
            else
            {
                existingOrder.IsDeleted = true;
            }

            await _ImcDbContext.SaveChangesAsync();
            return existingOrder;
        }

        //-->  Get Order By Id
        public async Task<order?> GetOrderById(Guid id)
        {
            return await _ImcDbContext.Orders
                .Include(o => o.OrderBy)
                .Include(o => o.OrderItems).FirstOrDefaultAsync(o => o.Id == id);
        }

        //-->  Get Orders
        public async Task<List<order>> GetOrders(string CurrentUserId, string userRole)
        {
            IQueryable<order> query = _ImcDbContext.Orders
            .Include(o => o.OrderBy)
            .Include(o => o.OrderTo)
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Service);

            if (userRole == "Admin")
            {
                return await query.ToListAsync();
            }
            else
            {
                return await query
                    .Where(o => !o.IsDeleted && o.OrderItems.Any(oi => oi.Service.CreatedById == CurrentUserId))
                    .ToListAsync();
            }
        }

        //-->  Update Order
        public async Task<order?> UpdateOrder(Guid id, JsonPatchDocument patch)
        {
            var Existing_Order = await _ImcDbContext.Orders.FirstOrDefaultAsync(o => o.Id == id);

            if (Existing_Order != null)
            {
                patch.ApplyTo(Existing_Order);

                _ImcDbContext.SaveChanges();
                return Existing_Order;
            }
            return null;
        }
    }
}