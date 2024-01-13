using imc_web_api.Models;
using imc_web_api.Service.AdminServices.NewFolder;
using Microsoft.EntityFrameworkCore;

namespace imc_web_api.Service.AdminServices.ManageFeedBackServicess
{
    public class ManageFeedBackService : IManageFeedbackService
    {
        private readonly ImcDbContext _imcDbContext;

        public ManageFeedBackService(ImcDbContext imcDbContext)
        {
            _imcDbContext = imcDbContext;
        }

        public async Task<feedback> AddFeedback(feedback FeedbackInputRequest)
        {
            try
            {
                if (FeedbackInputRequest == null)
                {
                    return null;
                }
                else
                {
                    var f = _imcDbContext.Feedbacks.AddAsync(FeedbackInputRequest);
                    await _imcDbContext.SaveChangesAsync();
                    return FeedbackInputRequest;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<feedback> DeleteFeedback(Guid id)
        {
            try
            {
                var checkFeedback = await _imcDbContext.Feedbacks.FirstOrDefaultAsync(x => x.Id == id);
                if (checkFeedback != null)
                {
                    return checkFeedback;
                }
                else
                {
                    throw new Exception("Feedback not found with this id:");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<feedback> GetFeedbackById(Guid id)
        {
            try
            {
                var fi = await _imcDbContext.Feedbacks.FirstOrDefaultAsync(x => x.Id == id);
                if (fi != null)
                {
                    return fi;
                }
                else
                {
                    throw new Exception("Feedback not found with this id:");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<feedback>> GetFeedbacks()
        {
            try
            {
                var af = await _imcDbContext.Feedbacks.ToListAsync();
                if (af != null)
                {
                    return af;
                }
                else
                {
                    throw new Exception("Not found any feedback:");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<feedback> UpdateFeedback(Guid id, feedback FeedbackInputReguest)
        {
            try
            {
                var uf = _imcDbContext.Feedbacks.First(x => x.Id == id);
                if (uf != null)
                {
                    return uf;
                }
                else
                {
                    throw new Exception("Feedback not found with this id:");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}