using imc_web_api.Dtos.AdminDtos.AgreementDtos;
using imc_web_api.Models;

namespace imc_web_api.Service.AdminServices.ManageAgreementServices
{
    public class ManageAgreementService : IManageAgreementService
    {
        public Task<agreement> AddAgreement(AgreementRequestDTO UserInputRequest)
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

        public Task<agreement> DeleteAgreement(Guid id)
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

        public Task<agreement> GetAgreementById(Guid id)
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

        public Task<List<agreement>> GetAgreements()
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