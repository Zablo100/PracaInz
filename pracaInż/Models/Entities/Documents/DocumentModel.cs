namespace pracaInż.Models.Entities.Documents
{
    public class DocumentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PathToFile { get; set; }
        public int Type { get; set; }
        public string Extension { get; set; }
    }
}
