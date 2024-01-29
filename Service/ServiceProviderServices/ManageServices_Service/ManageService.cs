using imc_web_api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace imc_web_api.Service.ServiceProviderService.ManageServices_Service.ManageServices
{
    public class ManageService : IManageService
    {
        private readonly ImcDbContext _dbContext;
        private readonly ILogger<ManageService> _logger;
        private readonly UserManager<user> _userManager;

        public ManageService(ImcDbContext dbContext, ILogger<ManageService> logger, UserManager<user> userManager)
        {
            _dbContext = dbContext;
            _logger = logger;
            _userManager = userManager;
        }

        //--> Add Service
        public async Task<service> AddService(service serviceInputRequest, Guid CurrentUserId)
        {
            try
            {
                if (serviceInputRequest != null)
                {
                    var LoggedInUser = await _userManager.Users.Include(u => u.ServiceProviderType).FirstOrDefaultAsync(u => u.Id == CurrentUserId.ToString());

                    if (LoggedInUser == null)
                    {
                        throw new Exception();
                    }

                    serviceInputRequest.CreatedByProviderTypeId = (Guid)LoggedInUser.ServiceProvidertypeId;
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
                _logger.LogError(ex.Message);
                throw new Exception("Failed to add service" + ex);
            }
        }

        //--> Delete Service
        public async Task<service> DeleteService(Guid id, Guid CurrentUserId)
        {
            try
            {
                var LoggedInUser = await _userManager.Users.Include(u => u.ServiceProviderType).FirstOrDefaultAsync(u => u.Id == CurrentUserId.ToString());

                var Service = await _dbContext.Services
                    .Where(s => s.Id == id && s.CreatedByProviderTypeId == LoggedInUser.ServiceProvidertypeId).FirstOrDefaultAsync();
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

        //--> Get Service By Id
        public async Task<service> GetServiceById(Guid id)
        {
            try
            {
                var Service = await _dbContext.Services.Include(s => s.ServiceProviderType).FirstOrDefaultAsync(x => x.Id == id);
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

        //--> Get Services
        public async Task<List<service>> GetServices()
        {
            try
            {
                return await _dbContext.Services.Include(s => s.ServiceProviderType).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving providers {ex.Message}");
            }
        }

        //--> Update Service
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