using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using pracaInż.Data;
using pracaInż.Models.DTO.Departments;
using pracaInż.Models.Entities.CompanyStructure;

namespace pracaInż.Services
{
    public interface IDepartmenService
    {
        Task<List<DepartmentListDTO>> GetDepartmentsWithoutEmployees();
        Task CreateNewDepartment(AddDepartmentDTO departmentDTO);
        Task ModifyDepartment(int id, JsonPatchDocument<Department> patchDocument);
    }
    public class DepartmenService : IDepartmenService
    {
        private readonly AppDbcontext _context;

        public DepartmenService(AppDbcontext context)
        {
            _context = context;
        }

        public async Task CreateNewDepartment(AddDepartmentDTO departmentDTO)
        {
            Factory? factory = await _context.Factorys.FindAsync(departmentDTO.FactoryId);
            if(factory == null)
            {
                //Error
                return;
            }
            Department department = new Department(departmentDTO, factory);

            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
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

        public async Task ModifyDepartment(int id, JsonPatchDocument<Department> patchDocument)
        {
            Department? department = await _context.Departments.FindAsync(id);
            if(department == null)
            {
                return;
            }
            patchDocument.ApplyTo(department);

            await _context.SaveChangesAsync();
        }
    }
}
