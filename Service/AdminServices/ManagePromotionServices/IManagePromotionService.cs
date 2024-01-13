using imc_web_api.Models;

namespace imc_web_api.Service.AdminServices.ManagePromotionServices
{
    public interface IManagePromotionService
    {
        Task<promotion> AddPromotion(promotion UserPromotionReguest);

        Task<promotion> UpdatePromotion(Guid id, promotion UserPromotionReguest);

        Task<promotion> GetPromotionById(Guid id);

        Task<List<promotion>> GetPromotions();

        Task<promotion> DeletePromotion(Guid id);
    }
}