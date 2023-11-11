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

        public DepartmenController(IDepartmenService service)
        {
            _service = service;

        }

        public ILoggingService LoggingService { get; }

        [HttpGet]
        [ActionName("GetDepartmentsWithoutEmployees")]
        public async Task<IActionResult> GetDepartmentsWithoutEmployees()
        {
            var departments = await _service.GetDepartmentsWithoutEmployees();

            return Ok(departments);
        }

        [HttpGet]
        [ActionName("GetDepartmentsWithEmployees")]
        public async Task<IActionResult> GetDepartmentsWithEmployees()
        {
            var departments = await _service.GetDepartmentsWithEmployees();

            return Ok(departments);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewDepartment([FromBody] AddDepartmentDTO departmentDTO)
        {
            var result = await _service.CreateNewDepartment(departmentDTO);
            if(result.IsError)
            {
                return BadRequest(result.FirstError);
            }

            return Ok(result.Value);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PartialUpdate(int id, [FromBody] JsonPatchDocument<Department> jsonPatch)
        {
            await _service.PartialUpdate(id, jsonPatch);
            
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> FullUpdate([FromBody] UpdateDepartmentDTO departmentDTO)
        {
            var result = await _service.FullUpdate(departmentDTO);
            if (result.IsError)
            {
                return BadRequest(result.FirstError);
            }

            return Ok(result.Value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteDepartment(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetDepartmentById(id);
            if (result.IsError)
            {
                return BadRequest(result.FirstError);
            }

            return Ok(result.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentsByFactoryId(int id)
        {
            //TODO: Błędy
            var result = await _service.GetDepartmentsByFactory(id);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> SearchDepartment([FromBody] DepartmentSearchDTO query)
        {
            var result = await _service.SearchByQuery(query);
            if (result.IsError)
            {
                return BadRequest(result.FirstError);
            }

            return Ok(result.Value);
        }
    }
}
