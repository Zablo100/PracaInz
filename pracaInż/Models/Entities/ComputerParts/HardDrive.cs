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

    }
}
