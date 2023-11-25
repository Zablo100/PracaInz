using pracaInż.Models.Entities.ComputerParts;

namespace pracaInż.Models.DTO.ComputerParts
{
    public class NewCPUModelDTO
    {
        public string Name { get; set; }
        public int NumberOfCores { get; set; }
        public double Frequency { get; set; }
        public double Score { get; set; }
        public CPUManufacurers Manufacturer { get; set; }
    }

    public class NewGPUModelDTO
    {
        public string Name { get; set; }
        public GraphicCardManufacturers Manufacturer { get; set; }
        public int Memory { get; set; }
        public string MemoryType { get; set; }
        public double Score { get; set; }
    }
    
    public class NewMotherboardModelDTO
    {
        public string Name { get; set; }
        public string Chipset { get; set; }
        public string Socket { get; set; }
        public int RAMSlots { get; set; }
    }

    public class NewRAMModelDTO
    {
        public string Name { get; set; }
        public string MemoryType { get; set; }
        public int Frequency { get; set; }
    }

    public class NewOSInfoDTO
    {
        public string Name { get; set; }
        public string CreatedBy { get; set; }
    }

    public class NewHardDriveModelDTO
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public Entities.ComputerParts.DriveType Type { get; set; }
        public double Score { get; set; }
    }


}
