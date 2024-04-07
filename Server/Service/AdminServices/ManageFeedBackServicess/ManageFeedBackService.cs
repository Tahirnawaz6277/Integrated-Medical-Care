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

        public async Task<feedback> AddFeedback(feedback feedbackInput, string CurrentUserId)
        {
            feedbackInput.ratedById = CurrentUserId;
            await _imcDbContext.Feedbacks.AddAsync(feedbackInput);
            await _imcDbContext.SaveChangesAsync();

            return feedbackInput;
        }

        public async Task<feedback?> DeleteFeedback(Guid id)
        {
            var checkFeedback = await _imcDbContext.Feedbacks
                .Include(f => f.Service)
                .Include(f => f.User).FirstOrDefaultAsync(x => x.Id == id);

            if (checkFeedback == null)
            {
                return null;
            }
            _imcDbContext.Feedbacks.Remove(checkFeedback);
            await _imcDbContext.SaveChangesAsync();
            return checkFeedback;
        }

        public async Task<feedback?> GetFeedbackById(Guid id)
        {
            return await _imcDbContext.Feedbacks.Include(f => f.Service).Include(f => f.User).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<feedback>> GetFeedbacks()
        {
            return await _imcDbContext.Feedbacks
                .Include(f => f.Service)
                .Include(f => f.User)
                

                .ToListAsync();
        }

        public async Task<feedback?> UpdateFeedback(Guid id, feedback feedbackInputRequest)
        {
            var ExistingFeedback = await _imcDbContext.Feedbacks.FirstOrDefaultAsync(p => p.Id == id);

            if (ExistingFeedback == null)
            {
                return null;
            }

            ExistingFeedback.Description = feedbackInputRequest.Description;
            ExistingFeedback.Rating = feedbackInputRequest.Rating;

            await _imcDbContext.SaveChangesAsync();

            return ExistingFeedback;
        }
    }
}