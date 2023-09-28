using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using pracaInż.Models.DTO.Departments;
using pracaInż.Models.Entities;
using pracaInż.Models.Entities.CompanyStructure;
using pracaInż.Services;

namespace pracaInż.Controllers
{
    [ApiController]
    [Route("api/department/[action]")]
    public class DepartmenController : Controller
    {
        private readonly IDepartmenService _service;
        private readonly ILoggingService _logger;

        public DepartmenController(IDepartmenService service, ILoggingService loggingService)
        {
            _service = service;
            _logger = loggingService;
        }

        public ILoggingService LoggingService { get; }

        [HttpGet]
        [ActionName("GetDepartmentsWithoutEmployees")]
        public async Task<IActionResult> GetDepartmentsWithoutEmployees()
        {
            var departments = await _service.GetDepartmentsWithoutEmployees();

            return Ok(departments);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewDepartment([FromBody] AddDepartmentDTO departmentDTO)
        {
            await _service.CreateNewDepartment(departmentDTO);
            _logger.LogActiviti("System Test", $"Utworzono nowy dział {departmentDTO.Name}", ActionType.Create);

            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PartialUpdate(int id, [FromBody] JsonPatchDocument<Department> jsonPatch)
        {
            await _service.PartialUpdate(id, jsonPatch);
            
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> FullUpdate([FromBody] AddDepartmentDTO departmentDTO)
        {
            await _service.FullUpdate(departmentDTO);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteDepartment(id);
            return Ok();
        }

    }
}
