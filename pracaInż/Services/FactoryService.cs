using Microsoft.EntityFrameworkCore;
using pracaInż.Data;
using pracaInż.Models.Entities.CompanyStructure;

namespace pracaInż.Services
{
    public interface IFactoryService
    {
        Task<List<Factory>> GetFactoriesAsync();
    }
    public class FactoryService : IFactoryService
    {
        private readonly AppDbcontext _context;
        public FactoryService(AppDbcontext context)
        {
            _context = context;
        }


        public async Task<List<Factory>> GetFactoriesAsync()
        {
            List<Factory> factories = await _context.Factorys.Include(Factory => Factory.Departments).ToListAsync();

            return factories;
        }
    }
}
