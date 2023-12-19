using pracaInż.Models.Entities.Documents;

namespace pracaInż.Models.DTO.Documents
{
    public class DocumentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DocumentType Type { get; set; }
        public string Extension { get; set; }
        public string CreateAt { get; set; }
        public string LastUpdate { get; set; }

        public DocumentDTO(DocumentModel document)
        {
            Id = document.Id;
            Name = document.Name;
            Type = (DocumentType)document.Type;
            Extension = document.Extension;
            CreateAt = document.CreateAt.ToString("dd-MM-yyyy");
            LastUpdate = document.LastUpdate.ToString("dd-MM-yyyy");
        }
    }
}
