namespace pracaInż.Models.Entities.Documents
{
    public enum DocumentType
    {
        Manual,
        PurchaseOrder,
        Contract,
        Offer
    }
    public class DocumentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PathToFile { get; set; }
        public int Type { get; set; }
        public string Extension { get; set; }
        public DateOnly CreateAt { get; set; }
        public DateOnly LastUpdate { get; set; }
    }
}
