using Microsoft.EntityFrameworkCore;
using pracaInż.Models.Entities;
using pracaInż.Models.Entities.CompanyStructure;
using pracaInż.Models.Entities.ComputerParts;
using pracaInż.Models.Entities.Documents;
using pracaInż.Models.Entities.Inventory;

namespace pracaInż.Data
{
    public class AppDbcontext : DbContext
    {
        public AppDbcontext(DbContextOptions options) : base(options) { }

        public DbSet<Processor> ProcessorModels { get; set; }
        public DbSet<GraphicsCard> GraphicsCardModels { get; set; }
        public DbSet<HardDrive> HardDrivesModels { get; set; }
        public DbSet<Motherboard> MotherboardModels { get; set; }
        public DbSet<Models.Entities.ComputerParts.OperatingSystem> OperatingSystems { get; set; }
        public DbSet<RAM> RAMModels { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Factory> Factorys { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Printer> Printers { get; set; }
        public DbSet<PrinterArcus> PrintersArcus { get; set;}
        public DbSet<Software> Software {  get; set; }
        public DbSet<ManualDocumentModel> ManualDocuments { get; set; }
        public DbSet<PurchaseOrderDoc> PurchaseOrderDocuments { get; set;}
    }
}
