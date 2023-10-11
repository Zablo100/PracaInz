using ErrorOr;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using pracaInż.Data;
using pracaInż.Models;
using pracaInż.Models.DTO.Factories;
using pracaInż.Models.Entities.CompanyStructure;
using pracaInż.Validators;

namespace pracaInż.Services
{
    public interface IFactoryService
    {
        Task<List<Factory>> GetFactoriesAsync();
        Task<List<FactoryDTO>> GetFactriesWithOutDepartments();
        Task<ErrorOr<FactoryDTO>> GetFactoryWithoutDepartmentsById(int Id);
        Task<ErrorOr<FactoryWithDepartmentDTO>> GetFactoryById(int Id);
        Task<ErrorOr<Created>> CreateNewFactory(AddFactoryDTO factoryDTO);
        Task<ErrorOr<Deleted>> DeleteFactory(int Id);
    }
    public class FactoryService : IFactoryService
    {
        private readonly AppDbcontext _context;
        public FactoryService(AppDbcontext context)
        {
            _context = context;
        }

        public async Task<ErrorOr<Created>> CreateNewFactory(AddFactoryDTO factoryDTO)
        {
            ErrorOr<Created> result;
            FactoryValidator validator = new FactoryValidator();
            Factory factory = new Factory(factoryDTO);

            ValidationResult validationResult = validator.Validate(factory);

            if(!validationResult.IsValid) 
            {
                result = Error.Validation(description: validationResult.Errors[0].ErrorMessage);
                return result;
            }
            _context.Factorys.Add(factory);
            await _context.SaveChangesAsync();

            result = Result.Created;
            return result;
        }

        public async Task<ErrorOr<Deleted>> DeleteFactory(int Id)
        {
            ErrorOr<Deleted> result;
            var factory = await _context.Factorys.FindAsync(Id);
            if(factory == null)
            {
                result = Error.NotFound(description: "Nie ma obiektu o podanym ID!");
                return result;
            }

            //_context.Factorys.Remove(factory);
            //await _context.SaveChangesAsync();
            
            result = Result.Deleted;
            return result;
        }

        public async Task<List<Factory>> GetFactoriesAsync()
        {
            List<Factory> factories = await _context.Factorys
                .Include(Factory => Factory.Departments)
                .ToListAsync();

            return factories;
        }

        public async Task<ErrorOr<FactoryWithDepartmentDTO>> GetFactoryById(int Id)
        {
            ErrorOr<FactoryWithDepartmentDTO> result;
            var factory = await _context.Factorys
                .Include(Factory => Factory.Departments)
                .FirstOrDefaultAsync(f => f.Id == Id);
            if(factory == null)
            {
                return result = Error.NotFound(description: "Nie ma fabryki o takim ID!");
            }
            result = new FactoryWithDepartmentDTO(factory);

            return result;
        }

        public async Task<ErrorOr<FactoryDTO>> GetFactoryWithoutDepartmentsById(int Id)
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
