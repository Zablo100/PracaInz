using Microsoft.AspNetCore.Mvc;
using pracaInż.Services;

namespace pracaInż.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _service;
        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeesBasicInfo()
        {
            var result = await _service.GetEmployeesBasicInfoList();
            if(result.IsError)
            {
                return BadRequest(result.FirstError);
            }

            return Ok(result.Value);
        }
    }
}
