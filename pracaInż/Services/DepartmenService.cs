using ErrorOr;
using FluentValidation.Results;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using pracaInż.Data;
using pracaInż.Models.DTO.Departments;
using pracaInż.Models.Entities.CompanyStructure;
using pracaInż.Validators;

namespace pracaInż.Services
{
    public interface IDepartmenService
    {
        Task<List<DepartmentListDTO>> GetDepartmentsWithoutEmployees();
        Task<List<DepartmentListWithEmployees>> GetDepartmentsWithEmployees();
        Task<ErrorOr<Created>> CreateNewDepartment(AddDepartmentDTO departmentDTO);
        Task PartialUpdate(int id, JsonPatchDocument<Department> patchDocument);
        Task<ErrorOr<Updated>> FullUpdate(UpdateDepartmentDTO departmentDTO);
        Task<ErrorOr<Deleted>> DeleteDepartment(int id);
        Task<ErrorOr<DepartmentDTO>> GetDepartmentById(int id);
        Task<List<DepartmentListDTO>> GetDepartmentsByFactory(int id);
    }
    public class DepartmenService : IDepartmenService
    {
        private readonly AppDbcontext _context;

        public DepartmenService(AppDbcontext context)
        {
            _context = context;
        }

        public async Task<ErrorOr<Created>> CreateNewDepartment(AddDepartmentDTO departmentDTO)
        {
            ErrorOr<Created> result;
            DepartmentValidation validator = new DepartmentValidation();

            ValidationResult validationResult = validator.Validate(departmentDTO);
            if (!validationResult.IsValid)
            {
                result = Error.Validation(description: validationResult.Errors[0].ErrorMessage);
                return result;
            }

            Factory? factory = await _context.Factorys.FindAsync(departmentDTO.FactoryId);
            if(factory == null)
            {
                result = Error.Validation(description: "Nie można przypisać działu do podanej fabryki!");
                return result;
            }
            Department department = new Department(departmentDTO, factory);


            _context.Departments.Add(department);
            await _context.SaveChangesAsync();

            result = Result.Created;
            return result;
        }

        public async Task<List<DepartmentListDTO>> GetDepartmentsWithoutEmployees()
        {
            List<Department> departments = await _context.Departments.Include(Departmen => Departmen.Factory).ToListAsync();

            List<DepartmentListDTO> result = new List<DepartmentListDTO>();
            foreach (Department department in departments)
            {
                result.Add(new DepartmentListDTO(department));  
            }

            return result;
        }

        public async Task PartialUpdate(int id, JsonPatchDocument<Department> patchDocument)
        {
            Department? department = await _context.Departments.FindAsync(id);
            if(department == null)
            {
                return;
            }
            patchDocument.ApplyTo(department);

            await _context.SaveChangesAsync();
        }

        public async Task<ErrorOr<Updated>> FullUpdate(UpdateDepartmentDTO departmentDTO)
        {
            ErrorOr<Updated> result;
            UpdateDepartmentValidation validator = new UpdateDepartmentValidation();

            ValidationResult validationResult = validator.Validate(departmentDTO);
            if (!validationResult.IsValid)
            {
                result = Error.Validation(description: validationResult.Errors[0].ErrorMessage);
                return result;
            }

            //Factory? factory = await _context.Factorys.FindAsync(departmentDTO.FactoryId);
            //if (factory == null)
            //{
            //    result = Error.Validation(description: "Nie odnaleziono fabryki, do której przypisany jest dział");
            //    return result;
            //}

            Department department = new Department(departmentDTO);

            _context.Departments.Update(department);
            await _context.SaveChangesAsync();

            result = Result.Updated;
            return result;

        }

        public async Task<ErrorOr<Deleted>> DeleteDepartment(int id)
        {
            ErrorOr<Deleted> result;
            Department? department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                result = Error.NotFound(description: "Nie odnaleziono działu o podanym ID!");
                return result;
            }

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();

            result = Result.Deleted;
            return result;
        }

        public async Task<List<DepartmentListWithEmployees>> GetDepartmentsWithEmployees()
        {
            List<Department> departments = await _context.Departments
                .Include(Departmen => Departmen.Factory)
                .Include(Dep => Dep.Employees)
                .ToListAsync();

            List<DepartmentListWithEmployees> result = new List<DepartmentListWithEmployees>();
            foreach (Department department in departments)
            {
                result.Add(new DepartmentListWithEmployees(department));
            }

            return result;
        }

        public async Task<ErrorOr<DepartmentDTO>> GetDepartmentById(int id)
        {
            ErrorOr<DepartmentDTO> result;
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                result = Error.NotFound(description: "Nie ma działu o podanym ID!");
                return result;
            }

            result = new DepartmentDTO(department);
            return result;
        }

        public async Task<List<DepartmentListDTO>> GetDepartmentsByFactory(int id)
        {
            var departments = await _context.Departments.Where(dep => dep.FactoryId == id).Include(dep => dep.Factory).ToListAsync();
            List<DepartmentListDTO> list = new List<DepartmentListDTO>();
            foreach (Department department in departments)
            {
                list.Add(new DepartmentListDTO(department));
            }

            return list;
        }
    }
}
