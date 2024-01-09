using imc_web_api.Models;

namespace imc_web_api.Service.AdminServices.ManageHCPServices
{
    public interface IManageHCPService
    {
        public Task AddProvider {get;set;}
        public Task DeleteProvider { get; set; }
        public Task UpdateProvider { get; set; }
        public Task<List<serviceprovidertype>> GetProviders { get; set; }

    }
}
