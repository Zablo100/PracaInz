using pracaInż.Models.Entities.CompanyStructure;
using pracaInż.Models.Entities.Documents;

namespace pracaInż.Models.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Seller { get; set; }
        public DateOnly Date { get; set; }
        public List<InvoiceItem> Items { get; set; }
        public decimal TotalCost { get; set; }
    }

    public class InvoiceItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }


        public Department Department { get; set; }
        public int DepartmentId { get; set; }

        public DocumentModel? PurchaseOrderDoc { get; set; }
        public int? PurchaseOrderDocId { get; set; }

        public Invoice Invoice { get; set; }
        public int InvoiceId { get; set; }
    }
}
