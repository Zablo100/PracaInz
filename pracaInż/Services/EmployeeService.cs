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
            var employees = await _context.Employees.Where(employee => employee.Department.FactoryId == factoryId)
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

        public Task<ErrorOr<EmployeeBasicInfoDTO>> GetEmployeeBasicInfoById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ErrorOr<List<EmployeeBasicInfoDTO>>> GetEmployeeBasicInfoList()
        {
            throw new NotImplementedException();
        }
    }
}
