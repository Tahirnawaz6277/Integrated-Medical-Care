﻿using imc_web_api.Dtos.HCPDtos;
using imc_web_api.Models;

using Microsoft.EntityFrameworkCore;

namespace imc_web_api.Service.AdminServices.ManageHCPServices
{
    public class ManageHCPServices : IManageHCPService
    {
        private readonly ImcDbContext _imcDbContext;

        public ManageHCPServices(ImcDbContext imcDbContext)
        {
            _imcDbContext = imcDbContext;
        }

        public async Task<serviceprovidertype> AddProvider(HCPRequestDTO UserInputReqest)
        {
            try
            {
                // Convert HCPRequestDTO to    serviceprovidertype Model
                var HCP = new serviceprovidertype
                {
                    ProviderName = UserInputReqest.ProviderName
                };

                if (UserInputReqest != null)
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
                throw new Exception("An error occurred while adding the provider." + ex.Message,ex);
            }
        }

        public async Task<serviceprovidertype> DeleteProvider(Guid id)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting provider with this ID  {ex.Message}");
            }
        }

        public async Task<List<serviceprovidertype>> GetProviders()
        {
            try
            {
                return await _imcDbContext.ServiceProviderTypes.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving providers {ex.Message}");
            }
        }

        public async Task<serviceprovidertype> GetProviderById(Guid id)
        {
            try
            {
                var checkhcp = await _imcDbContext.ServiceProviderTypes.FirstOrDefaultAsync(sp => sp.Id == id);
                if (checkhcp == null)
                {
                    return null;
                }
                return checkhcp;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<serviceprovidertype> UpdateProvider(Guid id, HCPRequestDTO inputRequestDTO)
        {
            try
            {
                var serviceProvider = await _imcDbContext.ServiceProviderTypes.FirstOrDefaultAsync(sp => sp.Id == id);

                if (serviceProvider != null)
                {
                    serviceProvider.ProviderName = inputRequestDTO.ProviderName;

                    await _imcDbContext.SaveChangesAsync();
                    return serviceProvider;
                }
                else
                {
                    throw new Exception("Provider Record Not Exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating provider with ID {id}: {ex.Message}");
            }
        }
    }
}