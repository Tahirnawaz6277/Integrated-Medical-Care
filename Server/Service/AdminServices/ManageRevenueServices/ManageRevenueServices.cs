using imc_web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace imc_web_api.Service.AdminServices.ManageRevenueServices
{
    public class ManageRevenueServices : IManageRevenueService
    {
        public ImcDbContext _ImcDbContext { get; set; }

        public ManageRevenueServices(ImcDbContext imcDbContext)
        {
            _ImcDbContext = imcDbContext;
        }

        public async Task<Revenue> AddRevenueAsync(Revenue revenue, string CurrentUserId)
        {
            revenue.PayerId = CurrentUserId;

            await _ImcDbContext.Revenues.AddAsync(revenue);
            await _ImcDbContext.SaveChangesAsync();

            return revenue;
        }

        public async Task<Revenue?> DeleteRevenueAsync(Guid id)
        {
            var revenue = await _ImcDbContext.Revenues.FirstOrDefaultAsync(r => r.Id == id);

            if (revenue is null)
            {
                return null;
            }

            _ImcDbContext.Revenues.Remove(revenue);
            _ImcDbContext.SaveChanges();

            return revenue;
        }

        public async Task<Revenue?> GetRevenueByIdAsync(Guid id)
        {
            return await _ImcDbContext.Revenues.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<List<Revenue>> GetRevenuesAsync()
        {
            return await _ImcDbContext.Revenues.Include(r => r.Payer).ToListAsync();
        }

        public async Task<Revenue?> UpdateRevenueAsync(Guid id, Revenue revenue)
        {
            var ExistingRevenue = await _ImcDbContext.Revenues.FindAsync(id);

            if (ExistingRevenue != null)
            {
                ExistingRevenue.Amount = revenue.Amount;
                ExistingRevenue.PayerId = revenue.PayerId;
                ExistingRevenue.PaymentMethod = revenue.PaymentMethod;

                await _ImcDbContext.SaveChangesAsync();
                return ExistingRevenue;
            }
            return null;
        }
    }
}