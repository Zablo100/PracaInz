using ErrorOr;
using Microsoft.EntityFrameworkCore;
using pracaInż.Data;
using pracaInż.Models.DTO;
using pracaInż.Models.Entities;

namespace pracaInż.Services
{
    public interface IPcLogService
    {
        Task<ErrorOr<List<PcLogDTO>>> GetPcLogsById(int id);
        Task<ErrorOr<Created>> AddPcLog(AddPcLogDTO addPcLog);
    }
    public class PcLogService : IPcLogService
    {
        private readonly AppDbcontext _dbcontext;
        public PcLogService(AppDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<ErrorOr<Created>> AddPcLog(AddPcLogDTO addPcLog)
        {
            ErrorOr<Created> result;
            var log = new PcLog(addPcLog);
            if(log.ComputerId == 0)
            {
                result = Error.Failure(description: "System nie mógł przypisać danej interakcji do komputera");
                return result;
            }
            _dbcontext.PcLogs.Add(log);
            await _dbcontext.SaveChangesAsync();

            result = Result.Created;
            return result;
        }

        public async Task<ErrorOr<List<PcLogDTO>>> GetPcLogsById(int id)
        {
            ErrorOr<List<PcLogDTO>> result;
            
            var raw = await _dbcontext.PcLogs
                .Where(log => log.ComputerId == id)
                .ToListAsync();

            if(raw.Count == 0)
            {
                result = Error.NotFound(description: "W komputerze nie dokonano jeszcze żadnych interwencji");
                return result;
            }

            result = raw.Select(log => new PcLogDTO(log)).ToList();
            return result;
        }
    }
}
