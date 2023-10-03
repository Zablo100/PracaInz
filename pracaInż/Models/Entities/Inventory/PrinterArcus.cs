namespace pracaInż.Models.Entities.Inventory
{
    public class PrinterArcus : Printer
    {
        public string SerialNumber { get; set; }
        public string InvoiceDescription { get; set; }
        public string ContractNumber { get; set; }
        public bool MonthlyCheck { get; set; }

    }
}
