using pracaInż.Models.DTO.ComputerParts;
using pracaInż.Models.Entities.ComputerParts;

namespace pracaInż.Models.Entities.Inventory
{
    public class ComputerOld : Item
    {
        public string Name { get; set; }
        public Processor CPU { get; set; }
        public int CPUId { get; set; }
        public GraphicsCard GPU { get; set; }
        public int? GPUId { get; set; }
        public Motherboard Motherboard { get; set; }
        public int MotherboardId { get; set; }
        public RAM RAM { get; set; }
        public int RAMId { get; set; }
        public ComputerParts.OperatingSystem OS { get; set; }
        public int OSId { get; set; }
        public int RAMCapacity { get; set; }
        public Employee? Employee { get; set; }
        public int? EmployeeId { get; set; }

        public List<HardDrive> HardDrives { get; set; }


        public ComputerOld()
        {
            
        }

        public ComputerOld(NewComputerDTO modelDTO)
        {
            Name = modelDTO.Name;
            CPUId = modelDTO.CPUId;
            GPUId = modelDTO.GPUId;
            MotherboardId = modelDTO.MotherboardId;
            OSId = modelDTO.OSId;
            RAMId = modelDTO.RAMId;
            RAMCapacity = modelDTO.RAMCapacity;

        }
    }

    public class Computer : Item
    {
        public string PcName { get; set; }
        public Employee? Employee { get; set; }
        public int? EmployeeId { get; set; }
        public byte Type { get; set; }
        public int TicketCount { get; set; }

        public Computer()
        {
            
        }
    }

}
