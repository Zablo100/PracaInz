using ErrorOr;
using pracaInż.Data;
using pracaInż.Models.Entities.Documents;

namespace pracaInż.Services
{
    public interface IDocumentService
    {
        Task<ErrorOr<ManualDocumentModel>> GetManualDocumentById(int id);
    }
    public class DocumentService : IDocumentService
    {
        private readonly AppDbcontext _context;
        public DocumentService(AppDbcontext appDbcontext)
        {
            _context = appDbcontext;
        }
        public async Task<ErrorOr<ManualDocumentModel>> GetManualDocumentById(int id)
        {
            ErrorOr<ManualDocumentModel> result;
            var doc = await _context.ManualDocuments.FindAsync(id);
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
