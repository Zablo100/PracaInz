using Microsoft.EntityFrameworkCore;
using pracaInż.Models.DTO.TicketDTO;
using pracaInż.Models.Entities.Inventory;
using System.ComponentModel.DataAnnotations.Schema;

namespace pracaInż.Models.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public Computer? Computer { get; set; }
        public int? ComputerId { get; set; }

        public List<Comment> comments { get; set; }

        public Ticket()
        {
            
        }

        public Ticket(NewTicketDTO ticketDTO)
        {
            Description = ticketDTO.Description;
            CreatedAt = DateTime.Now;
            ComputerId = ticketDTO.ComputerId;
        }

    }

    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }

        public Ticket Ticket { get; set; }
        public int TicketId { get; set; }

        public Comment()
        {
            
        }

        public Comment(AddCommentDTO modelDTO)
        {
            Text = modelDTO.Text;
            CreatedAt = DateTime.Now;
            TicketId = modelDTO.TicketId;
        }
    }
}
