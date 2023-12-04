using pracaInż.Models.Entities;
using pracaInż.Models.Entities.Inventory;
using System.Text;

namespace pracaInż.Models.DTO.TicketDTO
{
    public class TicketDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public string CreatedAt { get; set; }
        public string AcceptedAt { get; set; }
        public string ResolvedAt { get; set; }
        public string SubmittedBy { get; set; }
        public string SubmittedByDepartment { get; set; }
        public string AcceptedBy { get; set; }
        public string Computer { get; set; }
        public int? ComputerId { get; set; }
        public List<CommentDTO> Comments { get; set; }

        public TicketDTO(Ticket ticket)
        {
            Id = ticket.Id;
            Description = ticket.Description;
            Status = ticket.Status;
            CreatedAt = ticket.CreatedAt.ToString("dd-MM-yyyy HH:mm");
            AcceptedAt = IsNull(ticket.AcceptedAt) ? "Nie przyjęto" : ticket.AcceptedAt.Value.ToString("dd-MM-yyyy HH:mm");
            ResolvedAt = IsNull(ticket.ResolvedAt) ? "Nie rozwiązano" : ticket.ResolvedAt.Value.ToString("dd-MM-yyyy HH:mm");
            AcceptedBy = IsNull(ticket.AcceptedBy) ? "Nie akceptowano" : $"{ticket.AcceptedBy.Name} {ticket.AcceptedBy.Surname}";
            SubmittedBy = ticket.SubmittedBy.Name + " " + ticket.SubmittedBy.Surname;
            SubmittedByDepartment = ticket.SubmittedBy.Department.ShortName;
            Computer = IsNull(ticket.Computer) ? "Nie wskazano" : ticket.Computer.InventoryNumber;
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
