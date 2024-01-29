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
            try
            {
                if (UserPromotionReguest == null)
                {
                    throw new ArgumentNullException(nameof(UserPromotionReguest), "Input is null.");
                }

                UserPromotionReguest.PromoteById = CurrentUserId;
                UserPromotionReguest.IsSent = true;
                await _imcDbContext.Promotions.AddAsync(UserPromotionReguest);

                await _imcDbContext.SaveChangesAsync();
                _emailSender.SendEmail("inamwebpro007@gmail.com", "Administrator Promotion Offer");

                return UserPromotionReguest;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding Promotion." + ex.Message, ex);
            }
        }

        //--> Delete Promotion
        public async Task<promotion> DeletePromotion(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentException("Invalid ID. Please provide a valid Promotion ID.");
                }

                var PromotionRecord = await _imcDbContext.Promotions
                    .Include(p => p.PromoteToUser)
                    .Include(p => p.PromoteByUser)
                    .FirstOrDefaultAsync(p => p.Id == id);

                if (PromotionRecord == null)
                {
                    throw new Exception($"Promotion with ID {id} not found.");
                }

                _imcDbContext.Promotions.Remove(PromotionRecord);

                await _imcDbContext.SaveChangesAsync();
                return PromotionRecord;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while Deleting Promotion Record!." + ex.Message, ex);
            }
        }

        //--> Get Single Promotion
        public async Task<promotion> GetPromotionById(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentException("Invalid ID. Please provide a valid Promotion ID.");
                }

                var PromotionRecord = await _imcDbContext.Promotions
                    .Include(p => p.PromoteToUser)
                    .Include(p => p.PromoteByUser)
                    .FirstOrDefaultAsync(p => p.Id == id);

                if (PromotionRecord == null)
                {
                    throw new Exception($"Promotion with ID {id} not found.");
                }

                return PromotionRecord;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while Fetching Promotion Record!." + ex.Message, ex);
            }
        }

        //--> Get All Promotions
        public async Task<List<promotion>> GetPromotions()
        {
            try
            {
                return await _imcDbContext.Promotions.Include(p => p.PromoteToUser).Include(p => p.PromoteByUser).ToListAsync(); ;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while Fetching Promotion Record!." + ex.Message, ex);
            }
        }

        //--> Update Promotion
        public async Task<promotion> UpdatePromotion(Guid id, promotion UserPromotionReguest)
        {
            try
            {
                if (UserPromotionReguest == null || id == Guid.Empty)
                {
                    throw new ArgumentNullException(nameof(UserPromotionReguest), "Input is null.");
                }

                var ExistingPromotion = await _imcDbContext.Promotions.FirstOrDefaultAsync(p => p.Id == id);

                if (ExistingPromotion == null)
                {
                    throw new Exception("Record Not Found!");
                }
                ExistingPromotion.Promotion_Type = UserPromotionReguest.Promotion_Type;
                ExistingPromotion.IsSent = UserPromotionReguest.IsSent;

                await _imcDbContext.SaveChangesAsync();

                return ExistingPromotion;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while Updating Promotion Record." + ex.Message, ex);
            }
        }
    }
}