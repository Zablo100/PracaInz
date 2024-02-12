using pracaInż.Models.DTO;
using pracaInż.Models.Entities.Inventory;

namespace pracaInż.Models.Entities
{
    public class PcLog
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public string Message { get; set; }
        public ComputerOld? Computer { get; set; }
        public int? ComputerId { get; set; }

        public PcLog()
        {
            
        }

        public PcLog(AddPcLogDTO modelDTO)
        {
            Date = DateOnly.FromDateTime(DateTime.Now);
            ComputerId = modelDTO.PcId;
            if(modelDTO.Type == 1)
            {
                Dictionary<int, string> keyValuePairs = new Dictionary<int, string>()
                {
                    { 0, "Klawiatura" },
                    { 1, "Myszka" },
                    { 2, "Kabel zasilający" },
                    { 3, "Zasilacz" }
                };
                Message = "Nastąpiła wymiana przedmoitu: " + keyValuePairs[modelDTO.Message];
            }
            else
            {
                Dictionary<int, string> keyValuePairs = new Dictionary<int, string>()
                {
                    { 0, "sprężonym powietrzem" },
                    { 1, "całkowite" },
                };
                Message = "Nastąpiła czyszczenie " + keyValuePairs[modelDTO.Message] + " komputera";
            }
        }
    }
}
