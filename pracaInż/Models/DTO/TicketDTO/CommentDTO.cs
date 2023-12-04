using pracaInż.Models.Entities;

namespace pracaInż.Models.DTO.TicketDTO
{
    public class CommentDTO
    {
        public string Text { get; set; }
        public string Date { get; set; }

        public CommentDTO(Comment commnet)
        {
            Text = commnet.Text;
            Date = commnet.CreatedAt.ToString("dd-MM HH:mm");
        }
    }

    public class AddCommentDTO
    {
        public string Text { get; set; }
        public int TicketId { get; set; }
    }
}
