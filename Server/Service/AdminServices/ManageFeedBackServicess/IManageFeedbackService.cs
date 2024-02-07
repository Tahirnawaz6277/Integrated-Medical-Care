using imc_web_api.Models;

namespace imc_web_api.Service.AdminServices.NewFolder
{
    public interface IManageFeedbackService

    {
        Task<feedback> AddFeedback(feedback FeedbackInputReguest, string CurrentUserId);

        Task<feedback?> UpdateFeedback(Guid id, feedback FeedbackInputReguest);

        Task<List<feedback>> GetFeedbacks();

        Task<feedback?> GetFeedbackById(Guid id);

        Task<feedback?> DeleteFeedback(Guid id);
    }
}