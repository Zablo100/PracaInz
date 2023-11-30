using pracaInż.Models.DTO.ComputerParts;

namespace pracaInż.Models.Entities.ComputerParts
{
    public class RAM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MemoryType { get; set; }
        public int Frequency { get; set; }

        public RAM()
        {
            
        }

        public RAM(NewRAMModelDTO modelDTO)
        {
            Name = modelDTO.Name;
            MemoryType = modelDTO.MemoryType;
            Frequency = modelDTO.Frequency;
        }
    }
}
