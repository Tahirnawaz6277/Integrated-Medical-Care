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
                    throw new Exception("Service not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add service", ex);
            }
        }

        public async Task<service> DeleteService(Guid id)
        {
            try
            {
                var Service = await _dbContext.Services.FirstOrDefaultAsync(x => x.Id == id);
                if (Service == null)
                {
                    return null;
                }
                else
                {
                    _dbContext.Services.Remove(Service);
                    await _dbContext.SaveChangesAsync();
                    return Service;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while Deleting Service with this id {ex.Message}");
            }
        }

        public async Task<service> GetServiceById(Guid id)
        {
            try
            {
                var Service = await _dbContext.Services.FirstOrDefaultAsync(x => x.Id == id);
                if (Service == null)
                {
                    return null;
                }
                else
                {
                    return Service;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving Service {ex.Message}");
            }
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

        public async Task<service> UpdateService(Guid id, service ServiceInputRequest)
        {
            try
            {
                if (id == null && ServiceInputRequest == null)
                {
                    return null;
                }
                else
                {
                    var ExistingService = await _dbContext.Services.FirstOrDefaultAsync(x => x.Id == id);
                    if (ExistingService != null)
                    {
                        ExistingService.ServiceName = ServiceInputRequest.ServiceName;
                        ExistingService.image = ServiceInputRequest.image;
                        ExistingService.Status = ServiceInputRequest.Status;
                        ExistingService.ServiceProviderType = ServiceInputRequest.ServiceProviderType;
                        ExistingService.Id = id;
                        ExistingService.charges = ServiceInputRequest.charges;
                        ExistingService.AvailableQuantity = ServiceInputRequest.AvailableQuantity;
                        ExistingService.TotalQuantity = ServiceInputRequest.TotalQuantity;
                        await _dbContext.SaveChangesAsync();
                        return ExistingService;
                    }
                    else
                    {
                        throw new Exception("Service Record Not Exist");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating Service with ID {id}: {ex.Message}");
            }
        }
    }
}