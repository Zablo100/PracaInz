using pracaInż.Models.Entities.ComputerParts;

namespace pracaInż.Models.Entities.Inventory
{
    public class Computer : Item
    {
        public Processor CPU { get; set; }
        public int CPUId { get; set; }
        public GraphicsCard GPU { get; set; }
        public int GPUId { get; set; }
        public Motherboard Motherboard { get; set; }
        public int MotherboardId { get; set; }
        public RAM RAM { get; set; }
        public int RAMId { get; set; }
        public ComputerParts.OperatingSystem OS { get; set; }
        public int OSId { get; set; }
        public int RAMCapacity { get; set; }


        public List<HardDrive> HardDrives { get; set; }
    }
}
