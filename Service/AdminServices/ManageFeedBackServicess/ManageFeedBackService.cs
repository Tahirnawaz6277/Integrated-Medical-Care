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

        public async Task<feedback> AddFeedback(feedback feedbackInput)
        {
            try
            {
                if (feedbackInput == null)
                {
                    throw new ArgumentNullException(nameof(feedbackInput), "Feedback input is null.");
                }
                else
                {
                    await _imcDbContext.Feedbacks.AddAsync(feedbackInput);
                    await _imcDbContext.SaveChangesAsync();

                    // Return the added feedback instead of the input request
                    return feedbackInput;
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while adding feedback. See inner exception for details.", ex);
            }
        }

        public async Task<feedback> DeleteFeedback(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentException("Invalid ID. Please provide a valid Feedback ID.");
                }
                var checkFeedback = await _imcDbContext.Feedbacks.Include(f => f.Service).Include(f => f.User).FirstOrDefaultAsync(x => x.Id == id);
                if (checkFeedback == null)
                {
                    throw new Exception($"Feedback with ID {id} not found.");
                }
                _imcDbContext.Feedbacks.Remove(checkFeedback);
                await _imcDbContext.SaveChangesAsync();
                return checkFeedback;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while Deleting Feedback Record!." + ex.Message, ex);
            }
        }

        public async Task<feedback> GetFeedbackById(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentException("Invalid ID. Please provide a valid Feedback ID.");
                }
                var checkFeedback = await _imcDbContext.Feedbacks.Include(f => f.Service).Include(f => f.User).FirstOrDefaultAsync(x => x.Id == id);
                if (checkFeedback == null)
                {
                    throw new Exception($"Feedback with ID {id} not found.");
                }
                return checkFeedback;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while Fetching Feedback Record!." + ex.Message, ex);
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
                throw new Exception("An error occurred while Fetching Feedback Record!." + ex.Message, ex);
            }
        }

        public async Task<feedback> UpdateFeedback(Guid id, feedback feedbackInputRequest)
        {
            try
            {
                if (feedbackInputRequest == null || id == Guid.Empty)
                {
                    throw new ArgumentNullException(nameof(feedbackInputRequest), "Input is null.");
                }

                var ExistingFeedback = await _imcDbContext.Feedbacks.FirstOrDefaultAsync(p => p.Id == id);

                if (ExistingFeedback == null)
                {
                    throw new Exception("Record Not Found!");
                }

                // If feedback with the given id is found, update its properties
                ExistingFeedback.Description = feedbackInputRequest.Description;
                ExistingFeedback.Rating = feedbackInputRequest.Rating;

                await _imcDbContext.SaveChangesAsync();

                return ExistingFeedback;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating feedback with id {id}. See inner exception for details.", ex);
            }
        }
    }
}