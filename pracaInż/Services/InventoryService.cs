using ErrorOr;
using Microsoft.EntityFrameworkCore;
using pracaInż.Data;
using pracaInż.Models;
using pracaInż.Models.DTO.Inventory;
using pracaInż.Models.Entities.Inventory;

namespace pracaInż.Services
{
    public interface IInventoryservice
    {
        Task<ErrorOr<Created>> AddInventoryAsset(AddInventoryAssetDTO asset);
        Task<PaginationResponse<List<InventoryAssetDTO>>> GetInventoryAssets(int page);
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

        public async Task<PaginationResponse<List<InventoryAssetDTO>>> GetInventoryAssets(int page)
        {
            var raw = await _context
                .InventoryAssets
                .Skip((page -1) * 10)
                .Take(10)
                .OrderBy(inv => inv.Id)
                .Include(asset => asset.Department).ToListAsync();

            var totalCount = await _context.InventoryAssets.CountAsync();

            var result = new PaginationResponse<List<InventoryAssetDTO>>
                (page, totalCount, 10, raw.Select(inv => new InventoryAssetDTO(inv)).ToList());

            return result;
        }
    }
}
