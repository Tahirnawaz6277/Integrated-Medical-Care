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
            var serviceProvider = await _imcDbContext.ServiceProviderTypes.FirstOrDefaultAsync(x => x.Id == id);

            if (serviceProvider != null)
            {
                _imcDbContext.ServiceProviderTypes.Remove(serviceProvider);
                await _imcDbContext.SaveChangesAsync();
                return serviceProvider;
            }

            return null;
        }

        public async Task<List<serviceprovidertype>> GetProviders()
        {
            return await _imcDbContext.ServiceProviderTypes
                .Include(p => p.givenServices)
                .Include(p => p.User)

                .ToListAsync();
        }

        public async Task<serviceprovidertype?> GetProviderById(Guid id)
        {
            return await _imcDbContext.ServiceProviderTypes.FirstOrDefaultAsync(sp => sp.Id == id);
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