using imc_web_api.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace imc_web_api.Service.AdminServices.ManageInventoryServices
{
    public interface IManageInventoryService

    {
        Task<List<Inventory>> GetInventoriesAsync();

        Task<Inventory?> GetInventoryByIdAsync(Guid id);

        Task<Inventory> AddInventoryAsync(Inventory inventory);

        Task<Inventory?> DeleteInventoryAsync(Guid id);

        Task<Inventory?> UpdateInventoryAsync(Guid id, Inventory inventory);
        Task<Inventory?> UpdateSingleInventoryAsync(Guid id, JsonPatchDocument<Inventory> jsonPatchDocument);

	}
}