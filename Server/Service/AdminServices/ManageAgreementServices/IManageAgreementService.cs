using imc_web_api.Dtos.AdminDtos.AgreementDtos;
using imc_web_api.Models;

namespace imc_web_api.Service.AdminServices.ManageAgreementServices
{
    public interface IManageAgreementService
    {
        Task<agreement> AddAgreement(AgreementRequestDTO UserInputRequest);
        Task<List<agreement>> GetAgreements();
        Task<agreement> GetAgreementById(Guid id);
        Task<agreement> DeleteAgreement(Guid id);
   
    }
}
