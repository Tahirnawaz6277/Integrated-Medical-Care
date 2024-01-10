using imc_web_api.Dtos.HCPDtos;
using imc_web_api.Models;

namespace imc_web_api.Service.AdminServices.ManageHCPServices
{
    public class ManageHCPServices : IManageHCPService
    {
        private readonly ImcDbContext _imcDbContext;

        public ManageHCPServices(ImcDbContext imcDbContext)
        {
            _imcDbContext = imcDbContext;
        }

        public async Task<serviceprovidertype> AddProvider(HCPRequestDTO UserInputRegest)
        {
            try
            {
                // Convert HCPRequestDTO to    serviceprovidertype Model
                var HCP = new serviceprovidertype
                {
                    ProviderName = UserInputRegest.ProviderName
                };

                if (UserInputRegest == null)
                {
                    throw new ArgumentNullException(nameof(UserInputRegest), "User input is null.");
                }

                if (UserInputRegest != null)
                {
                    var AddedProvider = await _imcDbContext.ServiceProviderTypes.AddAsync(HCP);
                    await _imcDbContext.SaveChangesAsync();

                    return HCP;
                }
                else
                {
                    throw new Exception("Failed to add provider.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the provider." + ex.Message);
            }
        }

        public Task DeleteProvider()
        {
            throw new NotImplementedException();
        }

        public Task<List<serviceprovidertype>> GetProviders()
        {
            throw new NotImplementedException();
        }

        public Task UpdateProvider()
        {
            throw new NotImplementedException();
        }
    }
}