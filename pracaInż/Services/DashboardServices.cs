using Microsoft.EntityFrameworkCore;
using pracaInż.Data;
using pracaInż.Models.Entities;
using pracaInż.Models.Entities.Inventory;
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
            var devices = await _context.Devices
                .Where(device => !(device is InventoryAsset))
                .ToListAsync();
            var status = new List<InfrastructureStatus>();

            var pingTasks = devices.Select(async device =>
            {
                PingReply reply = await new Ping().SendPingAsync(device.IPAddress);

                if (reply.Status == IPStatus.Success)
                {
                    status.Add(new InfrastructureStatus(device, "Online"));
                }
                else
                {
                    status.Add(new InfrastructureStatus(device, "Offline"));
                }
            });

            await Task.WhenAll(pingTasks);

            return status;
        }
    }
}
