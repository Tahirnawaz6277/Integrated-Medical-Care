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
        public async Task<service?> AddService(service serviceInputRequest, Guid CurrentUserId)
        {
            var CurrentLoggedInUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == CurrentUserId.ToString());

            if (CurrentLoggedInUser == null)
            {
                return null;
            }

            serviceInputRequest.CreatedById = CurrentLoggedInUser.Id;
            serviceInputRequest.QualityTermsAgreedWithAdmin = serviceInputRequest.QualityTermsAgreedWithAdmin;
            serviceInputRequest.Status = false;

            await _dbContext.AddAsync(serviceInputRequest);
            await _dbContext.SaveChangesAsync();
            return serviceInputRequest;
        }

        //--> Get Service By Id
        public async Task<service?> GetServiceById(Guid id)
        {
            return await _dbContext.Services.Include(s => s.User).FirstOrDefaultAsync(x => x.Id == id);
        }

        //--> Get Services
        public async Task<List<service>> GetServices(string? userId = null)
        {
            if (userId != null)
            {
                return await _dbContext.Services
                    .Where(p => p.CreatedById == userId)
                    .Include(s => s.User)
                    .ToListAsync();
            }
            else
            {
                // Return all services
                return await _dbContext.Services
                    .Include(s => s.User)
                    .ToListAsync();
            }
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
            

                ExistingService.Id = id;
                ExistingService.charges = ServiceInputRequest.charges;
                ExistingService.AvailableQuantity = ServiceInputRequest.AvailableQuantity;
                ExistingService.TotalQuantity = ServiceInputRequest.TotalQuantity;
                ExistingService.QualityTermsAgreedWithAdmin = true;
                ExistingService.Status = ServiceInputRequest.Status;

                await _dbContext.SaveChangesAsync();
                return ExistingService;
            }

            return null;
        }

        //--> Delete Service
        public async Task<service> DeleteService(Guid id)


        {

			var fdbks = _dbContext.Feedbacks.Where(x => x.ratedToId == id).ToList();
			_dbContext.Feedbacks.RemoveRange(fdbks);


			// Find all order items related to the service
			var orderItems = await _dbContext.OrderItems.Where(o => o.ServiceId == id).ToListAsync();

			// Remove order items
			_dbContext.OrderItems.RemoveRange(orderItems);



			var Service = await _dbContext.Services.FindAsync(id);
            if (Service == null)
            {
                return null;
            }

            _dbContext.Services.Remove(Service);
            await _dbContext.SaveChangesAsync();
  
            return Service;
        }
    }
}