using Microsoft.AspNetCore.Mvc;
using pracaInż.Data;
using pracaInż.Models.DTO;
using pracaInż.Services;

namespace pracaInż.Controllers
{
    [ApiController]
    [Route("Computers/[action]")]
    public class ComputerController : Controller
    {
        private readonly IComputerService _service;
        private readonly IPcLogService _logService;
        public ComputerController(
            IComputerService service,
            IPcLogService pcLogService
            )
        {
            _service = service;
            _logService = pcLogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComputers()
        {
            var result = await _service.GetComputerList();

            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetComputerById(id);
            if(result.IsError)
            {
                return BadRequest(result.FirstError);
            }

            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> AddLogs(AddPcLogDTO addPcLog)
        {
            var result = await _logService.AddPcLog(addPcLog);
            if (result.IsError)
            {
                return BadRequest(result.FirstError);
            }

            return Ok(result.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLogsByPc(int id)
        {
            var result = await _logService.GetPcLogsById(id);
            if(result.IsError)
            {
                return NotFound(result.FirstError);
            }

            return Ok(result.Value);
        }
    }
}
