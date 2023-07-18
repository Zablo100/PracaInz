namespace pracaInż.Models.Entities.ComputerParts
{
    public class GPU
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Memory { get; set; }
        public string MemoryType { get; set; }
        public int PowerConsumption { get; set; }
        public double Score { get; set; }

    }
}
