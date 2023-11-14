using Microsoft.AspNetCore.Mvc;
using pracaInż.Models.DTO.SoftwareDTOs;
using pracaInż.Services;

namespace pracaInż.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SoftwareController : Controller
    {
        private readonly ISoftwareService _service;
        public SoftwareController(ISoftwareService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddNewSoftware(AddSoftwareDTO softwareDTO)
        {
            var result = await _service.AddNewSoftwareInfo(softwareDTO);
            if (result.IsError)
            {
                return BadRequest(result.FirstError);
            }

            return Ok(result.Value);
        }

        [HttpDelete("{id}")]
        public async  Task<IActionResult> DeleteSoftware(int id)
        {
            var result = await _service.DeleteSoftwareInfo(id);
            if (result.IsError)
            {
                return BadRequest(result.FirstError);
            }

            return Ok(result.Value);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSoftware(SoftwareDTO softwareDTO)
        {
            var result = await _service.UpdateSoftwareInfo(softwareDTO);
            if (result.IsError)
            {
                return BadRequest(result.FirstError);
            }

            return Ok(result.Value);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSoftwareList()
        {
            var result = await _service.GetAllSoftwareInfo();
            if(result.IsError) 
            {
                return BadRequest(result.FirstError);
            }

            return Ok(result.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSoftwareById(int id)
        {
            var result = await _service.GetSoftwareInfo(id);
            if (result.IsError)
            {
                return BadRequest(result.FirstError);
            }

            return Ok(result.Value);
        }
    
    }
}
