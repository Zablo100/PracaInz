using ErrorOr;
using Microsoft.EntityFrameworkCore;
using pracaInż.Data;
using pracaInż.Models.Entities.Documents;

namespace pracaInż.Services
{
    public interface IDocumentService
    {
        Task<ErrorOr<DocumentModel>> GetManualDocumentById(int id);
        Task<ErrorOr<List<DocumentModel>>> GetAllDocuments();
    }
    public class DocumentService : IDocumentService
    {
        private readonly AppDbcontext _context;
        public DocumentService(AppDbcontext appDbcontext)
        {
            _context = appDbcontext;
        }

        public async Task<ErrorOr<List<DocumentModel>>> GetAllDocuments()
        {
            ErrorOr<List<DocumentModel>> result;
            var documents = await _context.Documents.ToListAsync();
            if(documents.Count == 0)
            {
                result = Error.NotFound(description: "Błąd podczas ładowania dokumnetów");
                return result;
            }

            result = documents;
            return result;

        }

        public async Task<ErrorOr<DocumentModel>> GetManualDocumentById(int id)
        {
            ErrorOr<DocumentModel> result;
            var doc = await _context.Documents.FindAsync(id);
            if (doc == null)
            {
                result = Error.NotFound(description: "Nie znaleziono pliku!");
                return result;
            }

            result = doc;
            return result;
        }
    }
}
