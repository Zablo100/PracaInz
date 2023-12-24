using pracaInż.Models.Entities.ComputerParts;
using pracaInż.Models.Entities.Inventory;

namespace pracaInż.Models.DTO.ComputerParts
{
    public class ComputerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProcessorName { get; set; }
        public string GraphicsCardName { get; set; }
        public string MotherboardName { get; set; }
        public string RamModel { get; set; }
        public string osName { get; set; }
        public int RAMCapacity { get; set; }
        public string YearOfPurches { get; set; }
        public string InventoryName { get; set; }

        public List<HardDrive> HardDrives { get; set; }

        public ComputerDTO(Computer computer)
        {
            Id = computer.Id;
            Name = computer.Name;
            ProcessorName = computer.CPU.Name;
            GraphicsCardName = computer.GPU.Name;
            MotherboardName = computer.Motherboard.Name;
            RamModel = computer.RAM.Name;
            osName = computer.OS.Name;
            YearOfPurches = computer.YearOfPurchase.Year.ToString();
            InventoryName = computer.InventoryNumber;
            HardDrives = computer.HardDrives;

        }
    }
}
