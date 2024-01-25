using imc_web_api.Models;
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
        public async Task<order> AddOrder(order UserInputReguest)
        {
            try
            {
                if (UserInputReguest == null)
                {
                    throw new ArgumentNullException(nameof(UserInputReguest), "Order input is null.");
                }
                else
                {
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
        public Task<order> DeleteOrder(Guid id)
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET ORDER BY ID
        public Task<order> GetOrderById(Guid id)
        {
            try
            {
                return null;
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
        public Task<order> UpdateOrder(Guid id, order UserInputReguest)
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}