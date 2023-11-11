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
        Task<List<FactoryWithDepartmentDTO>> GetFactoriesAsync();
        Task<List<FactoryDTO>> GetFactriesWithOutDepartments();
        Task<ErrorOr<FactoryDTO>> GetFactoryWithoutDepartmentsById(int Id);
        Task<ErrorOr<FactoryWithDepartmentDTO>> GetFactoryById(int Id);
        Task<ErrorOr<Created>> CreateNewFactory(AddFactoryDTO factoryDTO);
        Task<ErrorOr<Deleted>> DeleteFactory(int Id);
        Task<ErrorOr<Updated>> UpdateFactory(FactoryWithDepartmentDTO factoryDTO);
        Task<ErrorOr<List<FactorySelectDTO>>> GetFactoryForSelect();
        Task<ErrorOr<List<FactoryDTO>>> SearchFactoryByQuery(string query);
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
            
            ValidationResult validationResult = validator.Validate(factoryDTO);

            if(!validationResult.IsValid) 
            {
                result = Error.Validation(description: validationResult.Errors[0].ErrorMessage);
                return result;
            }

            Factory factory = new Factory(factoryDTO);

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
                result = Error.NotFound(description: "Nie ma fabryki o podanym ID!");
                return result;
            }

            _context.Factorys.Remove(factory);
            await _context.SaveChangesAsync();
            
            result = Result.Deleted;
            return result;
        }

        public async Task<List<FactoryWithDepartmentDTO>> GetFactoriesAsync()
        {
            List<Factory> factories = await _context.Factorys
                .Include(Factory => Factory.Departments)
                .ToListAsync();

            List<FactoryWithDepartmentDTO> results = new List<FactoryWithDepartmentDTO>();

            foreach(var fact in factories)
            {
                results.Add(new FactoryWithDepartmentDTO(fact));
            }

            return results;
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

        public async Task<ErrorOr<List<FactorySelectDTO>>> GetFactoryForSelect()
        {
            ErrorOr<List<FactorySelectDTO>> result;
            var factoryies = await _context.Factorys.ToListAsync();
            if(factoryies.Count == 0) 
            { 
                result = Error.NotFound(description: "Błąd podczas ładowania danych");
                return result;
            }

            List<FactorySelectDTO> results = new List<FactorySelectDTO>();
            foreach( var factory in factoryies)
            {
                results.Add(new FactorySelectDTO(factory));
            }

            result = results;
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

        public async Task<ErrorOr<List<FactoryDTO>>> SearchFactoryByQuery(string query)
        {
            ErrorOr<List<FactoryDTO>> result;
            var rawData = await _context.Factorys
                .Where(factory => factory.City.Contains(query) || factory.PostalCode.Contains(query) || factory.Street.Contains(query))
                .ToListAsync();

            if(rawData.Count == 0)
            {
                result = Error.NotFound(description: "Nie znaleziono fabryki spełniającej podane kryteria");
                return result;
            }

            List<FactoryDTO> factories = new List<FactoryDTO>();
            foreach(var factory in rawData)
            {
                factories.Add(new FactoryDTO(factory));
            }

            result = factories;
            return result;
        }

        public async Task<ErrorOr<Updated>> UpdateFactory(FactoryWithDepartmentDTO factoryDTO)
        {
            ErrorOr<Updated> result;
            UpdateFactoryValidator validator = new UpdateFactoryValidator();

            ValidationResult validationResult = await validator.ValidateAsync(factoryDTO);
            if (!validationResult.IsValid)
            {
                result = Error.Validation(description: validationResult.Errors[0].ErrorMessage);
            }

            var factory = await _context.Factorys
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == factoryDTO.Id);

            if (factory == null)
            {
                result = Error.NotFound(description: "Nie ma fabryki o podanym ID!");
                return result;
            }

            Factory updatetedFactory = new Factory(factoryDTO, factory);

            _context.Factorys.Update(updatetedFactory);
            await _context.SaveChangesAsync();

            result = Result.Updated;
            return result;
        }
    }
}
