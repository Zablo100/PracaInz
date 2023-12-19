using pracaInż.Models.Entities;

namespace pracaInż.Models.DTO.Invoices
{
    public class InvoiceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Seller { get; set; }
        public string Date { get; set; }
        public List<InvoiceItemDTO> Items { get; set; }
        public decimal TotalCost { get; set; }

        public InvoiceDTO(Invoice invoice)
        {
            Id = invoice.Id;
            Name = invoice.Name;
            Seller = invoice.Seller;
            Date = invoice.Date.ToString("dd-MM-yyyy");
            TotalCost = invoice.TotalCost;
            Items = invoice.Items.Select(item => new InvoiceItemDTO(item)).ToList();
        }
    }
    
    public class InvoiceItemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentShrotName { get; set; }
        public string? PurchaseOrderDocName {  get; set; }
        public int? PurchaseOrderDocId { get; set; }

        public InvoiceItemDTO(InvoiceItem item)
        {
            Id = item.Id;
            Name = item.Name;
            Quantity = item.Quantity;
            Description = item.Description;
            Price = item.Price;
            DepartmentName = item.Department.Name;
            DepartmentShrotName = item.Department.ShortName;
            if(item.PurchaseOrderDoc != null)
            {
                PurchaseOrderDocName = item.PurchaseOrderDoc.Name;
                PurchaseOrderDocId = item.PurchaseOrderDocId;
            }
        }
    }

}
