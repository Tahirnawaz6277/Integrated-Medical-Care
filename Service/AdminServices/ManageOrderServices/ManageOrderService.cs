using imc_web_api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
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

        // POST ORDER
        public async Task<order> AddOrder(order UserInputReguest, string UserId)
        {
            try
            {
                if (UserInputReguest == null)
                {
                    throw new ArgumentNullException(nameof(UserInputReguest), "Order input is null.");
                }
                else
                {
                    UserInputReguest.CustomerId = UserId;
                    await _ImcDbContext.Orders.AddAsync(UserInputReguest);
                    _ImcDbContext.SaveChanges();

                    return UserInputReguest;
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while Order" + ex.Message);
            }
        }

        // DELETE ORDER
        public async Task<order> DeleteOrder(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentNullException(nameof(id), "input null Exception.");
                }
                else
                {
                   var Existing_Order = await  _ImcDbContext.Orders.FirstOrDefaultAsync(o => o.Id == id);

                    if(Existing_Order == null)
                    {
                        throw new Exception("Order Record Not Found!");
                    }

                    _ImcDbContext.Remove(Existing_Order);
                    await _ImcDbContext.SaveChangesAsync();
                    return Existing_Order;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET ORDER BY ID
        public async Task<order> GetOrderById(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException();
            }
            try
            {
                return await _ImcDbContext.Orders.Include(o => o.User).Include(o => o.Service).FirstOrDefaultAsync(o => o.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET ORDERS
        public async Task<List<order>> GetOrders()
        {
            try
            {
                return await _ImcDbContext.Orders.Include(o => o.User).Include(o => o.Service).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // UPDATE ORDER
        public async Task<order> UpdateOrder(Guid id, order UserInputReguest)
        {
            try
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
                else
                {
                    throw new Exception("Order Record Not Exist!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}