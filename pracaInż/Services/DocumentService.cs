using ErrorOr;
using Microsoft.EntityFrameworkCore;
using pracaInż.Data;
using pracaInż.Models.Entities.Documents;
using System.Text;

namespace pracaInż.Services
{
    public interface IDocumentService
    {
        Task<ErrorOr<DocumentModel>> GetManualDocumentById(int id);
        Task<ErrorOr<List<DocumentModel>>> GetAllDocuments();
        Task<ErrorOr<Created>> UploadNewFile(DocumentModel document, IFormFile file);
        Task<ErrorOr<Updated>> UpdateDocument(int id, IFormFile file);
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

        public async Task<ErrorOr<Updated>> UpdateDocument(int id, IFormFile file)
        {
            ErrorOr<Updated> result;
            var doc = await _context.Documents.FindAsync(id);
            if(doc == null)
            {
                result = Error.NotFound(description: "Wystąpił błąd podczas ładowania pliku");
                return result;
            }


            var filePath = Path.Combine(Environment.CurrentDirectory, "Files", file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                try
                {
                    await file.CopyToAsync(stream);
                }
                catch (IOException e)
                {
                    result = Error.Failure(description: "Wystąpił nieoczekiwany błąd poczas zapisywania pliku!");
                    //TODO: Log exception
                }
            }

            if (doc.PathToFile != filePath)
            {
                doc.PathToFile = filePath;
            }

            result = Result.Updated;
            return result;
        }

        public async Task<ErrorOr<Created>> UploadNewFile(DocumentModel document, IFormFile file)
        {
            ErrorOr<Created> result;
            if(file == null || file.Length == 0)
            {
                result = Error.NotFound();
                return result;
            }

            //TODO: walidacja
            var filePath = Path.Combine(Environment.CurrentDirectory, "Files", file.FileName);

            if (File.Exists(filePath))
            {
                result = Error.Conflict(description: "Plik już istnieje!");
                return result;
            }

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                try
                {
                    await file.CopyToAsync(stream);
                }
                catch(IOException e)
                {
                    result = Error.Failure(description: "Wystąpił nieoczekiwany błąd poczas zapisywania pliku!");
                    //TODO: Log exception
                }
            }

            result = Result.Created;
            return result;

        }
    }
}
