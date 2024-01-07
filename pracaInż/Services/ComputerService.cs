using ErrorOr;
using Microsoft.EntityFrameworkCore;
using pracaInż.Data;
using pracaInż.Models;
using pracaInż.Models.DTO.ComputerParts;
using pracaInż.Models.Entities.ComputerParts;
using pracaInż.Models.Entities.Inventory;
using OperatingSystem = pracaInż.Models.Entities.ComputerParts.OperatingSystem;

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

        Task<PaginationResponse<List<ComputerDTO>>> GetComputerList(int page);
        Task<List<Processor>> GetProcessorList();
        Task<List<GraphicsCard>> GetGraphicsCardList();
        Task<List<Motherboard>> GetMotherboardList();
        Task<List<RAM>> GetRAMList();
        Task<List<HardDrive>> GetHardDriveList();
        Task<List<OperatingSystem>> GetOperatingSystemList();

        Task<ErrorOr<ComputerDTO>> GetComputerById(int id);

    }
    public class ComputerService : IComputerService
    {
        //TODO: Uzupełnić walidacje dla każdego z modeli
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

        public async Task<ErrorOr<Created>> AddNewHardDrivesModel(NewHardDriveModelDTO HardDriveDTO)
        {
            ErrorOr<Created> result;
            var hardDrive = new HardDrive(HardDriveDTO);

            _context.HardDrivesModels.Add(hardDrive);
            await _context.SaveChangesAsync();

            result = Result.Created;
            return result;
        }

        public async Task<ErrorOr<Created>> AddNewMotherboardModel(NewMotherboardModelDTO motherboardDTO)
        {
            ErrorOr<Created> result;
            var motherboard = new Motherboard(motherboardDTO);

            _context.MotherboardModels.Add(motherboard);
            await _context.SaveChangesAsync();  

            result = Result.Created;
            return result;
        }

        public async Task<ErrorOr<Created>> AddNewOSInfo(NewOSInfoDTO osDTO)
        {
            ErrorOr<Created > result;
            var os = new Models.Entities.ComputerParts.OperatingSystem(osDTO);

            _context.OperatingSystems.Add(os);
            await _context.SaveChangesAsync();

            result = Result.Created;
            return result;
        }

        public async Task<ErrorOr<Created>> AddNewPC(NewComputerDTO computerDTO)
        {
            ErrorOr<Created> result;
            var computer = new Computer(computerDTO);

            _context.Computers.Add(computer);
            await _context.SaveChangesAsync();

            result = Result.Created;
            return result;
        }

        public async Task<ErrorOr<Created>> AddNewRAMModel(NewRAMModelDTO ramDTO)
        {
            ErrorOr<Created> result;
            var ram = new RAM(ramDTO);

            _context.RAMModels.Add(ram);
            await  _context.SaveChangesAsync();

            result = Result.Created;
            return result;
        }

        public async Task<ErrorOr<ComputerDTO>> GetComputerById(int id)
        {
            ErrorOr<ComputerDTO> result;

            var comp = await _context.Computers
                .Include(comp => comp.OS)
                .Include(comp => comp.CPU)
                .Include(comp => comp.RAM)
                .Include(comp => comp.GPU)
                .Include(comp => comp.RAM)
                .Include(comp => comp.HardDrives)
                .Include(comp => comp.Motherboard)
                .Include(comp => comp.Employee)
                .ThenInclude(emp => emp.Department)
                .FirstOrDefaultAsync(comp => comp.Id == id);

            if(comp == null)
            {
                result = Error.NotFound(description: "Nie można załadować komputer o podanym ID");
                return result;
            }

            result = new ComputerDTO(comp);
            return result;
        }

        public async Task<PaginationResponse<List<ComputerDTO>>> GetComputerList(int page)
        {
            var computers = await _context.Computers
                .Skip((page - 1) * 10)
                .Take(10)
                .OrderBy(comp => comp.Id)
                .Include(comp => comp.OS)
                .Include(comp => comp.CPU)
                .Include(comp => comp.RAM)
                .Include(comp => comp.GPU)
                .Include(comp => comp.RAM)
                .Include(comp => comp.HardDrives)
                .Include(comp => comp.Motherboard)
                .Include(comp => comp.Employee)
                .ThenInclude(emp => emp.Department)
                .ToListAsync();

            var totalCount = await _context.Computers.CountAsync();

            var result = new PaginationResponse
                <List<ComputerDTO>>
                (page, totalCount, 10,  computers.Select(comp => new ComputerDTO(comp)).ToList());

            return result;
        }

        public Task<List<GraphicsCard>> GetGraphicsCardList()
        {
            throw new NotImplementedException();
        }

        public Task<List<HardDrive>> GetHardDriveList()
        {
            throw new NotImplementedException();
        }

        public Task<List<Motherboard>> GetMotherboardList()
        {
            throw new NotImplementedException();
        }

        public Task<List<OperatingSystem>> GetOperatingSystemList()
        {
            throw new NotImplementedException();
        }

        public Task<List<Processor>> GetProcessorList()
        {
            throw new NotImplementedException();
        }

        public Task<List<RAM>> GetRAMList()
        {
            throw new NotImplementedException();
        }
    }
}
