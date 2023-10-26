using ErrorOr;
using Microsoft.EntityFrameworkCore;
using pracaInż.Data;
using pracaInż.Models.DTO.Employees;

namespace pracaInż.Services
{
    public interface IEmployeeService
    {
        Task<ErrorOr<List<EmployeeBasicInfoDTO>>> GetEmployeeBasicInfoList();
        Task<ErrorOr<List<EmployeeBasicInfoDTO>>> GetEmployeeBasicInfoByFactory(int factoryId);
        Task<ErrorOr<EmployeeBasicInfoDTO>> GetEmployeeBasicInfoById(int id);
    }
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbcontext _context;

        public EmployeeService(AppDbcontext context)
        {
            _context = context;            
        }

        public async Task<ErrorOr<List<EmployeeBasicInfoDTO>>> GetEmployeeBasicInfoByFactory(int factoryId)
        {
            ErrorOr<List<EmployeeBasicInfoDTO>> result;
            var employees = await _context.Employees.Include(emp => emp.Department).Where(employee => employee.Department.FactoryId == factoryId)
                .ToListAsync();

            if(employees.Count >= 0)
            {
                result = Error.NotFound(description: "Nie znaleziono żadnych pracowników dla podanej placówki!");
                return result;
            }

            List<EmployeeBasicInfoDTO> emploeesDTOs = new List<EmployeeBasicInfoDTO> ();
            foreach (var employee in employees)
            {
                emploeesDTOs.Add(new EmployeeBasicInfoDTO(employee));
            }

            result = emploeesDTOs;
            return result;
        }

        public async Task<ErrorOr<EmployeeBasicInfoDTO>> GetEmployeeBasicInfoById(int id)
        {
            ErrorOr<EmployeeBasicInfoDTO> result;
            var employee = await _context.Employees
                .Include(emp => emp.Department)
                .FirstOrDefaultAsync(emp => emp.Id == id);
            if(employee == null)
            {
                result = Error.NotFound(description: "Nie znależono pracownika o podanym ID");
                return result;
            }

            result = new EmployeeBasicInfoDTO(employee);
            return result;
        }

        public async Task<ErrorOr<List<EmployeeBasicInfoDTO>>> GetEmployeeBasicInfoList()
        {
            ErrorOr<List<EmployeeBasicInfoDTO>> result;
            var rawData = await _context.Employees.Include(emp => emp.Department).ToListAsync();
            if(rawData.Count < 0) 
            {
                result = Error.NotFound(description: "Nie znaleziono żadnych pracowników!");
                return result;
            }

            List<EmployeeBasicInfoDTO> employeeBasicInfoDTOs = new List<EmployeeBasicInfoDTO> ();
            foreach(var employee in rawData)
            {
                employeeBasicInfoDTOs.Add(new EmployeeBasicInfoDTO(employee));
            }

            result = employeeBasicInfoDTOs;
            return result;

        }
    }
}
