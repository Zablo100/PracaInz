using pracaInż.Models.Entities.ComputerParts;

namespace pracaInż.Models.Entities
{
    public class Computer : Item
    {
        public CPU CPU { get; set; }
        public GPU GPU { get; set; }
        public Motherboard Motherboard { get; set; }
        public RAM RAM { get; set; }
        public int RAMSlotsInUse { get; set; }
        public int RAMCapacity { get; set; }


        public List<HardDrive> HardDrives { get; set; }
    }
}
