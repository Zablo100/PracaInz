using Microsoft.AspNetCore.Mvc;
using pracaInż.Models.DTO.Inventory;
using pracaInż.Models.Entities.Inventory;
using pracaInż.Services;

namespace pracaInż.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class InventoryController : Controller
    {
        private readonly IInventoryservice _service;
        public InventoryController(IInventoryservice service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetInventoryAssets(int page)
        {
            return Ok(await _service.GetInventoryAssets(page));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAssetById(int id)
        {
            var result = await _service.GetAssetById(id);
            if (result.IsError)
            {
                return BadRequest(result.FirstError);
            }

            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewAsset(AddInventoryAssetDTO assetDTO)
        {
            var result = await _service.AddInventoryAsset(assetDTO);
            if (result.IsError)
            {
                return BadRequest(result.FirstError);
            }

            return Ok(result.Value);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsset(UpdateInventoryAssetDTO assetDTO)
        {
            var result = await _service.EditAsset(assetDTO);
            if (result.IsError)
            {
                return BadRequest(result.FirstError);
            }

            return Ok(result.Value);
        }
    }
}
