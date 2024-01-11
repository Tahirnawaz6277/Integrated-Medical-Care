using imc_web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace imc_web_api.Service.ServiceProviderService.ManageServices_Service.ManageServices
{
    public class ManageServices_Service : IManageServices_Service
    {
        private readonly ImcDbContext _dbContext;

        public ManageServices_Service(ImcDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<service> AddService(service serviceInputRequest)
        {
            try
            {
                if (serviceInputRequest != null)
                {
                    await _dbContext.AddAsync(serviceInputRequest);
                    await _dbContext.SaveChangesAsync();
                    return serviceInputRequest;
                }
                else
                {
                    throw new Exception("Service input request cannot be null");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add service", ex);
            }
        }

        public Task<service> DeleteService(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<service> GetServiceById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<service>> GetServices()
        {
            try
            {
                return await _dbContext.Services.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving providers {ex.Message}");
            }
        }

        public Task<service> UpdateService(Guid id, service ServiceInputRequest)
        {
            throw new NotImplementedException();
        }
    }
}