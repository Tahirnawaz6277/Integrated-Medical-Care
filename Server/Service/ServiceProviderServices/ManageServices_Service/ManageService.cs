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
            var CurrentLoggedInUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == CurrentUserId.ToString());

            if (CurrentLoggedInUser != null && CurrentLoggedInUser.ServiceProvidertypeId != null)
            {
                serviceInputRequest.CreatedByProviderTypeId = CurrentLoggedInUser.ServiceProvidertypeId;
                serviceInputRequest.CreatedByAdminId = null;
                await _dbContext.AddAsync(serviceInputRequest);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                serviceInputRequest.CreatedByAdminId = CurrentLoggedInUser.Id;
                serviceInputRequest.CreatedByProviderTypeId = null;

                await _dbContext.AddAsync(serviceInputRequest);
                await _dbContext.SaveChangesAsync();
            }

            return serviceInputRequest;
        }

        //--> Get Service By Id
        public async Task<service?> GetServiceById(Guid id)
        {
            return await _dbContext.Services.Include(s => s.ServiceProviderType).Include(s => s.User).FirstOrDefaultAsync(x => x.Id == id);
        }

        //--> Get Services
        public async Task<List<service>> GetServices()
        {
            return await _dbContext.Services.Include(s => s.ServiceProviderType).Include(s => s.User).ToListAsync();
        }

        //--> Update Service
        public async Task<service?> UpdateService(Guid id, service ServiceInputRequest)
        {
            if (id == Guid.Empty || ServiceInputRequest == null)
            {
                return null;
            }

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

            return null;
        }

        //--> Delete Service
        public async Task<service> DeleteService(Guid id)
        {
           
            var Service = await _dbContext.Services.FirstOrDefaultAsync(s => s.Id == id);
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
    }
}