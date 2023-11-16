using ErrorOr;
using Microsoft.EntityFrameworkCore;
using pracaInż.Data;
using pracaInż.Models.DTO.Inventory;
using pracaInż.Models.Entities.Inventory;

namespace pracaInż.Services
{
    public interface IInventoryservice
    {
        Task<ErrorOr<Created>> AddInventoryAsset(AddInventoryAssetDTO asset);
        Task<List<InventoryAssetDTO>> GetInventoryAssets();
        Task<ErrorOr<Updated>> EditAsset(UpdateInventoryAssetDTO assetDTO);
        Task<ErrorOr<InventoryAsset>> GetAssetById(int id);
    }
    public class InventoryService : IInventoryservice
    {
        private readonly AppDbcontext _context;
        public InventoryService(AppDbcontext context)
        {
            _context = context;
        }

        public async Task<ErrorOr<Created>> AddInventoryAsset(AddInventoryAssetDTO asset)
        {
            ErrorOr<Created> result;
            //TODO: Walidacja
            InventoryAsset inventoryAsset = new InventoryAsset(asset);
            _context.InventoryAssets.Add(inventoryAsset);
            await _context.SaveChangesAsync();

            result = Result.Created;
            return result;

        }

        public async Task<ErrorOr<Updated>> EditAsset(UpdateInventoryAssetDTO assetDTO)
        {
            ErrorOr<Updated> result;
            InventoryAsset inventoryAsset = new InventoryAsset(assetDTO);

            _context.InventoryAssets.Update(inventoryAsset);
            await _context.SaveChangesAsync();

            result = Result.Updated;
            return result;
        }

        public async Task<ErrorOr<InventoryAsset>> GetAssetById(int id)
        {
            ErrorOr<InventoryAsset> result;
            var asset = await _context.InventoryAssets.FindAsync(id);
            if(asset == null)
            {
                result = Error.NotFound(description: "Nie można wczytać informacji o podanej pozycji!");
                return result;
            }

            result = asset;
            return result;
        }

        public async Task<List<InventoryAssetDTO>> GetInventoryAssets()
        {
            var raw = await _context.InventoryAssets.Include(asset => asset.Department).ToListAsync();
            var result = new List<InventoryAssetDTO>();
            raw.ForEach(raw => result.Add(new InventoryAssetDTO(raw)));

            return result;
        }
    }
}
