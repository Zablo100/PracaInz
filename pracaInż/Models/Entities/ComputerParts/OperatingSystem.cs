using pracaInż.Models.DTO.ComputerParts;

namespace pracaInż.Models.Entities.ComputerParts
{
    public class OperatingSystem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }

        public OperatingSystem()
        {
            
        }

        public OperatingSystem(NewOSInfoDTO modelDTO)
        {
            Name = modelDTO.Name;
            CreatedBy = modelDTO.CreatedBy;
        }

    }
}
