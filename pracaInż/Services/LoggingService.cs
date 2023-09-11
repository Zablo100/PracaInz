using pracaInż.Data;
using pracaInż.Models.Entities;

namespace pracaInż.Services
{
    public interface ILoggingService
    {
        public void LogHardwareActiviti(string user, string description, HardwareType hardwareType, ActionType actionType);
    }
    public class LoggingService : ILoggingService
    {
        AppDbcontext _context;

        public LoggingService(AppDbcontext context)
        {
            _context = context;
        }
        public void LogHardwareActiviti(string user, string description, HardwareType hardwareType, ActionType actionType)
        {
            Log log = new Log(user, description, hardwareType, actionType);

            _context.Logs.Add(log);
        }
    }
}
