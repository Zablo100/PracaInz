using pracaInż.Models.Entities.ComputerParts;
using pracaInż.Models.Entities.Inventory;

namespace pracaInż.Models.DTO.ComputerParts
{
    public class ComputerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProcessorName { get; set; }
        public int ProcessorManufacturer {  get; set; }
        public double ProcessorScore { get; set; }
        public string GraphicsCardName { get; set; }
        public int GraphicsCardManufacturer { get; set; }
        public double GraphicsCardScore { get; set; }
        public string MotherboardName { get; set; }
        public string RamModel { get; set; }
        public string RamType { get; set; }
        public string osName { get; set; }
        public int RAMCapacity { get; set; }
        public string YearOfPurches { get; set; }
        public string InventoryName { get; set; }
        public double TotalScore { get; set; }
        public string Person {  get; set; }


        public List<HardDrive> HardDrives { get; set; }

        public ComputerDTO(Computer computer)
        {
            Id = computer.Id;
            Name = computer.Name;
            ProcessorName = computer.CPU.Name;
            ProcessorManufacturer = (int)computer.CPU.Manufacturer;
            ProcessorScore = computer.CPU.Score;
            GraphicsCardName = computer.GPU.Name;
            GraphicsCardManufacturer = (int)computer.GPU.Manufacturer;
            GraphicsCardScore = computer.GPU.Score;
            MotherboardName = computer.Motherboard.Name;
            RamModel = computer.RAM.Name;
            RAMCapacity = computer.RAMCapacity;
            RamType = computer.RAM.MemoryType;
            osName = computer.OS.Name;
            YearOfPurches = computer.YearOfPurchase.Year.ToString();
            InventoryName = computer.InventoryNumber;
            HardDrives = computer.HardDrives;
            TotalScore = computer.CPU.Score + computer.GPU.Score + computer.HardDrives.Sum(drive => drive.Score);

            if(computer.Employee != null)
            {
                Person = $"[{computer.Employee.Department.ShortName}] {computer.Employee.Name} {computer.Employee.Surname}";
            }
            else
            {
                Person = "Brak osoby";
            }

        }
    }
}
