using imc_web_api.Models;
using imc_web_api.Service.AdminServices.NewFolder;

namespace imc_web_api.Service.AdminServices.ManageFeedBackServicess
{
    public class ManageFeedBackService : IManageFeedbackService
    {
        private readonly ImcDbContext _imcDbContext;

        public ManageFeedBackService(ImcDbContext imcDbContext)
        {
            _imcDbContext = imcDbContext;
        }

        public Task<feedback> AddFeedback(feedback FeedbackInputReguest)
        {
            try
            {
                return null;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<feedback> DeleteFeedback(Guid id)
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

        public Task<feedback> GetFeedbackById(Guid id)
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

        public Task<List<feedback>> GetFeedbacks()
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

        public Task<feedback> UpdateFeedback(Guid id, feedback FeedbackInputReguest)
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