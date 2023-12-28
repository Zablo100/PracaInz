using pracaInż.Models.DTO.ComputerParts;

namespace pracaInż.Models.Entities.ComputerParts
{
    public enum GraphicCardManufacturers
    {
        Intel = 1,
        AMD,
        Nvidia
    }
    public class GraphicsCard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GraphicCardManufacturers Manufacturer { get; set; }
        public int Memory { get; set; }
        public string MemoryType { get; set; }
        public double Score { get; set; }

        public GraphicsCard()
        {

        }

        public GraphicsCard(NewGPUModelDTO modelDTO)
        {
            Name = modelDTO.Name;
            Manufacturer = modelDTO.Manufacturer;
            Memory = modelDTO.Memory;
            MemoryType = modelDTO.MemoryType;
            Score = modelDTO.Score;
        }
    }
}
