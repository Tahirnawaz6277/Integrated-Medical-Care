using imc_web_api.Models;

namespace imc_web_api.Service.AuthServices
{
    public interface IQualificationService
    {

        public Task<user_qualification> AddQualification(user_qualification UserInputRequest);
        public Task<user_qualification> UpdateQualification(Guid id, user_qualification UserInputRequest);
        public Task<List<user_qualification>> GetQualification();
        public Task<user_qualification> GetQualificationById(Guid id);
        public Task<user_qualification> DeleteQualificationById(Guid id);


    }
}
