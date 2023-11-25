using ErrorOr;
using pracaInż.Data;
using pracaInż.Models.DTO.ComputerParts;
using pracaInż.Models.Entities.ComputerParts;

namespace pracaInż.Services
{
    public interface IComputerService
    {
        Task<ErrorOr<Created>> AddNewCPUModel(NewCPUModelDTO cpuDTO);
        Task<ErrorOr<Created>> AddNewGPUModel(NewGPUModelDTO gpuDTO);
        Task<ErrorOr<Created>> AddNewMotherboardModel(NewMotherboardModelDTO motherboardDTO);
        Task<ErrorOr<Created>> AddNewRAMModel(NewRAMModelDTO ramDTO);
        Task<ErrorOr<Created>> AddNewHardDrivesModel(NewHardDriveModelDTO HardDriveDTO);
        Task<ErrorOr<Created>> AddNewOSInfo(NewOSInfoDTO osDTO);
        Task<ErrorOr<Created>> AddNewPC(NewComputerDTO computerDTO);

    }
    public class ComputerService : IComputerService
    {
        private readonly AppDbcontext _context;

        public ComputerService(AppDbcontext context)
        {
            _context = context; 
        }

        public async Task<ErrorOr<Created>> AddNewCPUModel(NewCPUModelDTO cpuDTO)
        {
            ErrorOr<Created> result;
            var cpu = new Processor(cpuDTO);

            _context.ProcessorModels.Add(cpu);
            await _context.SaveChangesAsync();

            result = Result.Created;
            return result;
        }

        public async Task<ErrorOr<Created>> AddNewGPUModel(NewGPUModelDTO gpuDTO)
        {
            ErrorOr<Created> result;
            var gpu = new GraphicsCard(gpuDTO);

            _context.GraphicsCardModels.Add(gpu);
            await _context.SaveChangesAsync();

            result = Result.Created;
            return result;
        }

        public Task<ErrorOr<Created>> AddNewHardDrivesModel(NewHardDriveModelDTO HardDriveDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ErrorOr<Created>> AddNewMotherboardModel(NewMotherboardModelDTO motherboardDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ErrorOr<Created>> AddNewOSInfo(NewOSInfoDTO osDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ErrorOr<Created>> AddNewPC(NewComputerDTO computerDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ErrorOr<Created>> AddNewRAMModel(NewRAMModelDTO ramDTO)
        {
            throw new NotImplementedException();
        }
    }
}
