using Microsoft.EntityFrameworkCore;
using pracaInż.Data;
using pracaInż.Models.DTO.Factories;
using pracaInż.Models.Entities.CompanyStructure;

namespace pracaInż.Services
{
    public interface IFactoryService
    {
        Task<List<Factory>> GetFactoriesAsync();
        Task<List<FactoryDTO>> GetFactriesWithOutDepartments();
        Task<FactoryDTO> GetFactoryWithoutDepartmentsById(int Id);
        Task<FactoryWithDepartmentDTO> GetFactoryById(int Id);
        Task CreateNewFactory(AddFactoryDTO factoryDTO);
        Task DeleteFactory(int Id);
    }
    public class FactoryService : IFactoryService
    {
        private readonly AppDbcontext _context;
        public FactoryService(AppDbcontext context)
        {
            _context = context;
        }

        public async Task CreateNewFactory(AddFactoryDTO factoryDTO)
        {
            Factory factory = new Factory(factoryDTO);

            _context.Factorys.Add(factory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFactory(int Id)
        {
            var factory = await _context.Factorys.FindAsync(Id);
            if(factory == null)
            {
                return; //TODO: Error
            }

            _context.Factorys.Remove(factory);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Factory>> GetFactoriesAsync()
        {
            List<Factory> factories = await _context.Factorys
                .Include(Factory => Factory.Departments)
                .ToListAsync();

            return factories;
        }

        public async Task<FactoryWithDepartmentDTO> GetFactoryById(int Id)
        {
            var factory = await _context.Factorys
                .Include(Factory => Factory.Departments)
                .FirstOrDefaultAsync(f => f.Id == Id);
            if(factory == null)
            {
                throw new Exception(); //TODO: Error
            }

            return new FactoryWithDepartmentDTO(factory);
        }

        public async Task<FactoryDTO> GetFactoryWithoutDepartmentsById(int Id)
        {
            var factory = await _context.Factorys.FindAsync(Id);
            if (factory == null)
            {
                throw new Exception(); //TODO: Error
            }

            return new FactoryDTO(factory);
        }

        public async Task<List<FactoryDTO>> GetFactriesWithOutDepartments()
        {
            var factories = await _context.Factorys.ToListAsync();
            List<FactoryDTO> result = new List<FactoryDTO>();
            foreach(var factory in factories)
            {
                result.Add(new FactoryDTO(factory));
            }

            return result;
        }
    }
}
