using AutoMapper;
using imc_web_api.Dtos.AdminDtos.HCPDtos;

using imc_web_api.Models;

using Microsoft.EntityFrameworkCore;

namespace imc_web_api.Service.AdminServices.ManageHCPServices
{
    public class ManageHCPServices : IManageHCPService
    {
        private readonly ImcDbContext _imcDbContext;
        private readonly IMapper _mapper;

        public ManageHCPServices(ImcDbContext imcDbContext, IMapper mapper)
        {
            _imcDbContext = imcDbContext;
            _mapper = mapper;
        }

        public async Task<serviceprovidertype> AddProvider(serviceprovidertype UserInputReqest)
        {
            await _imcDbContext.ServiceProviderTypes.AddAsync(UserInputReqest);

            await _imcDbContext.SaveChangesAsync();

            return UserInputReqest;
        }

        public async Task<serviceprovidertype?> DeleteProvider(Guid id)
        {
            var serviceProvider = await _imcDbContext.ServiceProviderTypes
                .Include(p => p.givenServices)
                .Include(p => p.Users)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (serviceProvider == null)
            {
                return null;
            }

            if (serviceProvider.Users != null)
            {
                foreach (var user in serviceProvider.Users.ToList())
                {
                    _imcDbContext.Users.Remove(user);
                }
            }
            // Remove each given service
            if (serviceProvider.givenServices != null)
            {
                foreach (var service in serviceProvider.givenServices.ToList())
                {
                    _imcDbContext.Services.Remove(service);
                }
            }

            _imcDbContext.ServiceProviderTypes.Remove(serviceProvider);
            await _imcDbContext.SaveChangesAsync();
            return serviceProvider;
        }

        public async Task<List<user>> GetProviders()
        {
            var serviceProviders = await _imcDbContext.Users
       .Where(sp => sp.Role == "ServiceProvider")
       .Include(sp => sp.ServiceProviderType)
       .Include(sp => sp.User_Feedbacks)

       .Include(sp => sp.services)
       .ToListAsync();

            return serviceProviders;
        }

        public async Task<user> GetProviderById(Guid id)
        {
            return await _imcDbContext.Users
                .Include(u => u.ServiceProviderType)
                .Include(u => u.services)
                   .ThenInclude(u => u.User_Feedbacks)

                  .Where(u => u.Id == id.ToString()).SingleAsync();
        }

        public async Task<serviceprovidertype?> UpdateProvider(Guid id, HCPRequestDTO inputRequestDTO)
        {
            var serviceProvider = await _imcDbContext.ServiceProviderTypes.FirstOrDefaultAsync(sp => sp.Id == id);

            if (serviceProvider != null)
            {
                serviceProvider.ProviderName = inputRequestDTO.ProviderName;

                await _imcDbContext.SaveChangesAsync();
                return serviceProvider;
            }
            return null;
        }
    }
}