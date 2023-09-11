namespace pracaInż.Models.Entities.ComputerParts
{
    public class Processor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfCores { get; set; }
        public double Frequency { get; set; }
        public string ProcessorBasePower { get; set; } // Moc potrzebna do zasilenia
        public double Score { get; set; }

    }
}
