using pracaInż.Models.Entities;

namespace pracaInż.Models.DTO
{
    public class PcLogDTO
    {
        public string Date { get; set; }
        public string Message { get; set; }

        public PcLogDTO(PcLog log)
        {
            Date = log.Date.ToString();
            Message = log.Message;
        }
    }

    public class AddPcLogDTO
    {
        public int PcId { get; set; }
        public int Type { get; set; }
        public int Message { get; set; }
    }
}
