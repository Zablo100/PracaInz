using Microsoft.EntityFrameworkCore;
using pracaInż.Data;
using pracaInż.Models.Entities;
using System.Net.NetworkInformation;

namespace pracaInż.Services
{
    public interface IDashboardServices
    {
        public Task<List<InfrastructureStatus>> getInfrastructureStatus();
    }
    public class DashboardServices : IDashboardServices
    {
        private readonly AppDbcontext _context;
        public DashboardServices(AppDbcontext context)
        {
            _context = context;
        }
        public async Task<List<InfrastructureStatus>> getInfrastructureStatus()
        {
            var devices = await _context.Devices.ToListAsync();
            var status = new List<InfrastructureStatus>();
            Ping ping = new Ping();

            foreach (var device in devices)
            {
                PingReply reply = ping.Send(device.IPAddress);

                if (reply.Status.ToString().Equals("Success"))
                {
                    status.Add(new InfrastructureStatus(device, "Online"));
                }
                else
                {
                    status.Add(new InfrastructureStatus(device, "Offline"));
                }

            }

            return status;
        }
    }
}
