using imc_web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace imc_web_api.Service.AdminServices.ManageInventoryServices
{
    public class ManageInventoryServices : IManageInventoryService
    {
        public ImcDbContext _ImcDbContext { get; }

        public ManageInventoryServices(ImcDbContext imcDbContext)
        {
            _ImcDbContext = imcDbContext;
        }

        public async Task<List<Inventory>> GetInventoriesAsync()
        {
            return await _ImcDbContext.Inventories.ToListAsync();
        }

        public async Task<Inventory?> GetInventoryByIdAsync(Guid id)
        {
            return await _ImcDbContext.Inventories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Inventory> AddInventoryAsync(Inventory inventory)
        {
            await _ImcDbContext.Inventories.AddAsync(inventory);

            await _ImcDbContext.SaveChangesAsync();

            return inventory;
        }

        public async Task<Inventory?> DeleteInventoryAsync(Guid id)
        {
            var inventory = await _ImcDbContext.Inventories.FirstOrDefaultAsync(o => o.Id == id);

            if (inventory is null)
            {
                return null;
            }

            _ImcDbContext.Inventories.Remove(inventory);
            _ImcDbContext.SaveChanges();

            return inventory;
        }

        public async Task<Inventory?> UpdateInventoryAsync(Guid id, Inventory InventoryRequest)
        {
            var inventory = await _ImcDbContext.Inventories.FindAsync(id);

            if (inventory != null)
            {
                inventory.Service = InventoryRequest.Service;
                inventory.TotalQuantity = InventoryRequest.TotalQuantity;
                inventory.AvailableQuantity = InventoryRequest.AvailableQuantity;

                await _ImcDbContext.SaveChangesAsync();
                return inventory;
            }
            return null;
        }
    }
}