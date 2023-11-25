namespace pracaInż.Models.DTO.ComputerParts
{
    public class NewComputerDTO
    {
        public string Name { get; set; }
        public int CPUId { get; set; }
        public int? GPUId { get; set; }
        public int MotherboardId { get; set; }
        public int RAMId { get; set; }
        public int OSId { get; set; }
        public int RAMCapacity { get; set; }
        public List<int> HardDrivesId { get; set; }
    }
}
