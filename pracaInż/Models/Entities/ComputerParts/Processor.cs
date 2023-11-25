using pracaInż.Models.DTO.ComputerParts;

namespace pracaInż.Models.Entities.ComputerParts
{
    public enum CPUManufacurers
    {
        Intel,
        AMD,
        Other
    }
    public class Processor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CPUManufacurers Manufacturer { get; set; }
        public int NumberOfCores { get; set; }
        public double Frequency { get; set; }
        public double Score { get; set; }

        public Processor()
        {

        }

        public Processor(NewCPUModelDTO modelDTO)
        {
            Name = modelDTO.Name;
            Manufacturer = modelDTO.Manufacturer;
            NumberOfCores = modelDTO.NumberOfCores;
            Frequency = modelDTO.Frequency;
            Score = modelDTO.Score;
        }

    }
}
