using pracaInż.Models.Entities;
using pracaInż.Models.Entities.Inventory;
using System.Text;

namespace pracaInż.Models.DTO.TicketDTO
{
    public class TicketDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string CreatedAt { get; set; }
        public string Computer { get; set; }
        public int? ComputerId { get; set; }
        public List<CommentDTO> Comments { get; set; }

        public TicketDTO(Ticket ticket)
        {
            Id = ticket.Id;
            Description = ticket.Description;
            CreatedAt = ticket.CreatedAt.ToString("dd-MM-yyyy HH:mm");
            Computer = IsNull(ticket.Computer) ? "Nie wskazano" : ticket.Computer.PcName;
            ComputerId = ticket.ComputerId;
        }

        private bool IsNull<T>(T x)
        {
            if (x == null)
            {
                return true;
            }
            return false;
        }
    }
}
