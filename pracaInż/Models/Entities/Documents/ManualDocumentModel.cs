namespace pracaInż.Models.Entities.Documents
{
    public class ManualDocumentModel : DocumentModel
    {
        public Software? Software { get; set; }
        public DateOnly CreateAt { get; set; }
        public DateOnly LastUpdate {  get; set; }

    }
}
