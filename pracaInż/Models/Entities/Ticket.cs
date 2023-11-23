using Microsoft.EntityFrameworkCore;
using pracaInż.Models.DTO.TicketDTO;
using pracaInż.Models.Entities.Inventory;
using System.ComponentModel.DataAnnotations.Schema;

namespace pracaInż.Models.Entities
{
    public enum Status
    {
        Pending,
        InProgress,
        Completed
    }
    public class Ticket
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? AcceptedAt { get; set; }
        public DateTime? ResolvedAt { get; set; }

        [ForeignKey("SubmittedById")]
        public Employee SubmittedBy { get; set; }
        public int SubmittedById { get; set; }

        [ForeignKey("AcceptedById")]
        public Employee? AcceptedBy { get; set; }
        public int? AcceptedById { get; set;}

        public Computer? Computer { get; set; }
        public int? ComputerId { get; set; }

        public List<Comment> comments { get; set; }

        public Ticket()
        {
            
        }

        public Ticket(NewTicketDTO ticketDTO)
        {
            Description = ticketDTO.Description;
            Status = Status.Pending;
            CreatedAt = DateTime.Now;
            ComputerId = ticketDTO.ComputerId;
            SubmittedById = ticketDTO.SubmittedById;
        }

    }

    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }

        public Ticket Ticket { get; set; }
        public int TicketId { get; set; }
    }
}
