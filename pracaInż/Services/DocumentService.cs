using ErrorOr;
using pracaInż.Data;
using pracaInż.Models.Entities.Documents;

namespace pracaInż.Services
{
    public interface IDocumentService
    {
        Task<ErrorOr<DocumentModel>> GetManualDocumentById(int id);
    }
    public class DocumentService : IDocumentService
    {
        private readonly AppDbcontext _context;
        public DocumentService(AppDbcontext appDbcontext)
        {
            _context = appDbcontext;
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
