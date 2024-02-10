using imc_web_api.Models;
using imc_web_api.Service.EmailServices;
using Microsoft.EntityFrameworkCore;

namespace imc_web_api.Service.AdminServices.ManagePromotionServices
{
    public class ManagePromotionService : IManagePromotionService
    {
        private readonly ImcDbContext _imcDbContext;
        private readonly IEmailSender _emailSender;

        public ManagePromotionService(ImcDbContext imcDbContext, IEmailSender emailSender)
        {
            _imcDbContext = imcDbContext;
            _emailSender = emailSender;
        }

        //--> Add Promotion
        public async Task<promotion> AddPromotion(promotion UserPromotionReguest, string CurrentUserId)
        {
            UserPromotionReguest.PromoteById = CurrentUserId;
            UserPromotionReguest.IsSent = true;
            await _imcDbContext.Promotions.AddAsync(UserPromotionReguest);

            await _imcDbContext.SaveChangesAsync();
            //_emailSender.SendEmail("inamwebpro007@gmail.com", "Administrator Promotion Offer");

            return UserPromotionReguest;
        }

        //--> Delete Promotion
        public async Task<promotion?> DeletePromotion(Guid id)
        {
            var PromotionRecord = await _imcDbContext.Promotions
                .Include(p => p.PromoteToUser)
                .Include(p => p.PromoteByUser)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (PromotionRecord == null)
            {
                return null;
            }

            _imcDbContext.Promotions.Remove(PromotionRecord);
            await _imcDbContext.SaveChangesAsync();
            return PromotionRecord;
        }

        //--> Get Single Promotion
        public async Task<promotion?> GetPromotionById(Guid id)
        {
            var PromotionRecord = await _imcDbContext.Promotions
                .Include(p => p.PromoteToUser)
                .Include(p => p.PromoteByUser)
                .FirstOrDefaultAsync(p => p.Id == id);

            return PromotionRecord;
        }

        //--> Get All Promotions
        public async Task<List<promotion>> GetPromotions()
        {
            return await _imcDbContext.Promotions.Include(p => p.PromoteToUser).Include(p => p.PromoteByUser).ToListAsync(); ;
        }

        //--> Update Promotion
        public async Task<promotion?> UpdatePromotion(Guid id, promotion UserPromotionReguest)
        {
            var ExistingPromotion = await _imcDbContext.Promotions.FirstOrDefaultAsync(p => p.Id == id);

            if (ExistingPromotion != null)
            {
                ExistingPromotion.Promotion_Type = UserPromotionReguest.Promotion_Type;
                ExistingPromotion.IsSent = UserPromotionReguest.IsSent;

                await _imcDbContext.SaveChangesAsync();
                return ExistingPromotion;
            }
            return null;
        }
    }
}