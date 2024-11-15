﻿using Microsoft.EntityFrameworkCore;
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

        public DbSet<Computer> Computers { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Log> Logs { get; set; }
        public virtual DbSet<Factory> Factorys { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Printer> Printers { get; set; }
        public DbSet<PrinterArcus> PrintersArcus { get; set;}
        public DbSet<Software> Software {  get; set; }
        public DbSet<InventoryAsset> InventoryAssets { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoicesItem { get; set; }
        public DbSet<DocumentModel> Documents { get; set; }
        public DbSet<PcLog> PcLogs { get; set; }

    }
}
