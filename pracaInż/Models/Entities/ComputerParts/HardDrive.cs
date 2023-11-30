using pracaInż.Models.DTO.ComputerParts;

namespace pracaInż.Models.Entities.ComputerParts
{
    public enum DriveType
    {
        HDD,
        SSD
    }
    public class HardDrive
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public DriveType Type { get; set; }
        public double Score { get; set; }

        public HardDrive()
        {
            
        }

        public HardDrive(NewHardDriveModelDTO modelDTO)
        {
            Name = modelDTO.Name;
            Type = modelDTO.Type;
            Size = modelDTO.Size;
            Score = modelDTO.Score;

        }
    }
}
