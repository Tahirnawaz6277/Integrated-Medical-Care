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

        public async Task<feedback> AddFeedback(feedback feedbackInput, string userId)
        {
            try
            {
                if (feedbackInput == null || userId == null)
                {
                    throw new ArgumentNullException(nameof(feedbackInput));
                }
                else
                {
                    feedbackInput.ratedById = userId;
                    await _imcDbContext.Feedbacks.AddAsync(feedbackInput);
                    await _imcDbContext.SaveChangesAsync();

                    return feedbackInput;
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
                if (id == Guid.Empty)
                {
                    throw new ArgumentNullException(nameof(id));
                }
                var checkFeedback = await _imcDbContext.Feedbacks.Include(f => f.Service).Include(f => f.User).FirstOrDefaultAsync(x => x.Id == id);
                if (checkFeedback == null)
                {
                    throw new ArgumentNullException();
                }
                _imcDbContext.Feedbacks.Remove(checkFeedback);
                await _imcDbContext.SaveChangesAsync();
                return checkFeedback;
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
                if (id == Guid.Empty)
                {
                    throw new ArgumentNullException(nameof(id));
                }
                var checkFeedback = await _imcDbContext.Feedbacks.Include(f => f.Service).Include(f => f.User).FirstOrDefaultAsync(x => x.Id == id);
                if (checkFeedback == null)
                {
                    throw new ArgumentNullException(nameof(id));
                }
                return checkFeedback;
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
                return await _imcDbContext.Feedbacks.Include(f => f.Service).Include(f => f.User).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<feedback> UpdateFeedback(Guid id, feedback feedbackInputRequest)
        {
            try
            {
                if (feedbackInputRequest == null || id == Guid.Empty)
                {
                    throw new ArgumentNullException(nameof(feedbackInputRequest));
                }

                var ExistingFeedback = await _imcDbContext.Feedbacks.FirstOrDefaultAsync(p => p.Id == id);

                if (ExistingFeedback == null)
                {
                    throw new ArgumentNullException(nameof(feedbackInputRequest));
                }

                ExistingFeedback.Description = feedbackInputRequest.Description;
                ExistingFeedback.Rating = feedbackInputRequest.Rating;

                await _imcDbContext.SaveChangesAsync();

                return ExistingFeedback;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}