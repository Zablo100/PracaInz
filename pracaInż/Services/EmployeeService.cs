using ErrorOr;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using pracaInż.Data;
using pracaInż.Models.DTO.Employees;
using pracaInż.Validators;

namespace pracaInż.Services
{
    public interface IEmployeeService
    {
        Task<ErrorOr<List<EmployeeBasicInfoDTO>>> GetEmployeesBasicInfoList();
        Task<ErrorOr<List<EmployeeBasicInfoDTO>>> GetEmployeesBasicInfoByFactory(int factoryId);
        Task<ErrorOr<EmployeeBasicInfoDTO>> GetEmployeeBasicInfoById(int id);
        Task<ErrorOr<Created>> AddNewEmployeeBasicInfo(AddEmployeeBasiInfoDTO employeeDTO);
        Task<ErrorOr<Updated>> UpdateEmployeeInfo(UpdateEmployeeDTO employeeDTO);
        Task<ErrorOr<Deleted>> DeleteEmployee(int id);
        Task<ErrorOr<List<EmployeeBasicInfoDTO>>> SearchByQuery(string query);

    }
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbcontext _context;

        public EmployeeService(AppDbcontext context)
        {
            _context = context;            
        }

        public async Task<ErrorOr<List<EmployeeBasicInfoDTO>>> GetEmployeesBasicInfoByFactory(int factoryId)
        {
            ErrorOr<List<EmployeeBasicInfoDTO>> result;
            var employees = await _context.Employees
                .Include(emp => emp.Department)
                .Where(employee => employee.Department.FactoryId == factoryId)
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
                .ThenInclude(dep => dep.Factory)
                .FirstOrDefaultAsync(emp => emp.Id == id);
            if(employee == null)
            {
                result = Error.NotFound(description: "Nie znależono pracownika o podanym ID");
                return result;
            }

            result = new EmployeeBasicInfoDTO(employee);
            return result;
        }

        public async Task<ErrorOr<List<EmployeeBasicInfoDTO>>> GetEmployeesBasicInfoList()
        {
            ErrorOr<List<EmployeeBasicInfoDTO>> result;
            var rawData = await _context.Employees
                .Include(emp => emp.Department)
                .ThenInclude(dep => dep.Factory)
                .ToListAsync();
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

        public async Task<ErrorOr<Created>> AddNewEmployeeBasicInfo(AddEmployeeBasiInfoDTO employeeDTO)
        {
            ErrorOr<Created> result;
            AddEmployeeValidator validator = new AddEmployeeValidator();
            ValidationResult validationResult = validator.Validate(employeeDTO);

            if (!validationResult.IsValid)
            {
                result = Error.Validation(description: validationResult.Errors[0].ErrorMessage);
                return result;
            }

            var department = await _context.Departments.FindAsync(employeeDTO.DepartmentId);
            if (department == null)
            {
                result = Error.NotFound(description: "Nie można przypisać działu do pracownika");
                return result;
            }

            var employee = new Employee(employeeDTO, department);
            _context.Employees.Add(employee);

            await _context.SaveChangesAsync();

            result = Result.Created;
            return result;
        }
        public async Task<ErrorOr<Updated>> UpdateEmployeeInfo(UpdateEmployeeDTO employeeDTO)
        {
            ErrorOr<Updated> result;
            UpdateEmployeeValidator validator = new UpdateEmployeeValidator();
            ValidationResult validationResult = validator.Validate(employeeDTO);

            if (!validationResult.IsValid)
            {
                result = Error.Validation(description: validationResult.Errors[0].ErrorMessage);
                return result;
            }

            var department = await _context.Departments.FindAsync(employeeDTO.DepartmentId);
            if (department == null)
            {
                result = Error.NotFound(description: "Nie można przypisać działu do pracownika");
                return result;
            }

            var employee = new Employee(employeeDTO, department);
            _context.Employees.Update(employee);

            await _context.SaveChangesAsync();

            result = Result.Updated;
            return result;
        }

        public async Task<ErrorOr<Deleted>> DeleteEmployee(int id)
        {
            ErrorOr<Deleted> result;
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                result = Error.NotFound(description: "Nie znaleziono pracownika o podanym ID");
                return result;
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            result = Result.Deleted;
            return result;
        }

        public async Task<ErrorOr<List<EmployeeBasicInfoDTO>>> SearchByQuery(EmployeeSearchDTO search)
        {
            ErrorOr<List<EmployeeBasicInfoDTO>> result;
            List<Employee> raw = new List<Employee>();

            if(search.DepartmentId == 0 && search.FactoryId == 0)
            {
                raw = await _context.Employees
                    .Include(emp => emp.)
                    .Where(emp =>
                    emp.Name.Contains(search.Query) ||
                    emp.Surname.Contains(search.Query) ||
                    emp.JobTitle.Contains(search.Query)
                    ).ToListAsync();
            }
            else if(search.FactoryId == 0)
            {
                raw = await _context.Employees
                    .Include(emp => emp.Department)
                    .Where(
                    emp => emp.DepartmentId == search.DepartmentId &&
                    emp.Name.Contains(search.Query) ||
                    emp.Surname.Contains(search.Query) ||
                    emp.JobTitle.Contains(search.Query)
                    ).ToListAsync();
            }
            else if(search.DepartmentId == 0)
            {
                raw = await _context.Employees
                    .Include(emp => emp.Department)
                    .ThenInclude(dep => dep.Factory)
                    .Where(
                    emp => emp.Department.FactoryId == search.FactoryId &&
                    emp.Name.Contains(search.Query) ||
                    emp.Surname.Contains(search.Query) ||
                    emp.JobTitle.Contains(search.Query) ||
                    emp.Department.ShortName.Contains(search.Query)
                    ).ToListAsync();
            }
            else
            {
                raw = await _context.Employees
                     .Include(emp => emp.Department)
                     .ThenInclude(dep => dep.Factory)
                     .Where(
                     emp => emp.DepartmentId == search.DepartmentId &&
                     emp.Department.FactoryId == search.FactoryId &&
                     emp.Name.Contains(search.Query) ||
                     emp.Surname.Contains(search.Query) ||
                     emp.JobTitle.Contains(search.Query) ||
                     emp.Department.ShortName.Contains(search.Query)
                     ).ToListAsync();
            }

            if(raw.Count() == 0)
            {
                result = Error.NotFound(description: "Nie ma wyników dla podanych parametrów");
                return result;
            }

            List<EmployeeBasicInfoDTO> employees = new List<EmployeeBasicInfoDTO>();
            raw.ForEach(emp => employees.Add(new EmployeeBasicInfoDTO(emp)));

            result = employees;
            return result;
        }

    }
}
