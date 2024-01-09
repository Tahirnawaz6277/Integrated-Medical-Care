using imc_web_api.Dtos.HCPDtos;
using imc_web_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace imc_web_api.Service.AdminServices.ManageHCPServices
{
    public class ManageHCPServices : IManageHCPService
    {
        private readonly ImcDbContext _imcDbContext;

        public ManageHCPServices(ImcDbContext imcDbContext)
        {
            _imcDbContext = imcDbContext;
        }

        public async Task<IActionResult> AddProvider(HCPRequestDTO UserInputRegest)
        {
            try
            {
                if (UserInputRegest != null)
                {
                   var addedProvider =  await _imcDbContext.AddAsync(UserInputRegest);
                   await _imcDbContext.SaveChangesAsync();

                    //var result = new serviceprovidertype
                    //{
                    //      addedProvider
                    //};

                    return null;
                }
                else
                {
                    throw new Exception("Failed to add provider.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the provider."+ ex.Message);
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