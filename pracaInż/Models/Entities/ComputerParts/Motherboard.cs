using pracaInż.Models.DTO.ComputerParts;

namespace pracaInż.Models.Entities.ComputerParts
{
    public class Motherboard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Chipset { get; set; }
        public string Socket { get; set; }
        public int RAMSlots { get; set; }

        public Motherboard()
        {
            
        }

        public Motherboard(NewMotherboardModelDTO modelDTO)
        {
            Name = modelDTO.Name;
            Chipset = modelDTO.Chipset;
            Socket = modelDTO.Socket;
            RAMSlots = modelDTO.RAMSlots;
        }

    }
}
