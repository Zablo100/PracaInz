using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using pracaInż.Services;

namespace pracaInż.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DocumentController : Controller
    {
        private readonly IDocumentService _service;

        public DocumentController(IDocumentService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetManualDocumentById(int id)
        {

            var result = await _service.GetManualDocumentById(id);
            if(result.IsError)
            {
                return BadRequest(result.FirstError);
            }

            byte[] pdfBytes = System.IO.File.ReadAllBytes(
                Path.Combine(Environment.CurrentDirectory, "Files", result.Value.PathToFile)
                );

            if (pdfBytes == null || pdfBytes.Length == 0)
            {
                return NotFound(Error.NotFound(description: "Błąd podczas ładowania pliku"));
            }

            return File(pdfBytes, "application/pdf");
        }

        [HttpGet]
        public async Task<IActionResult> GetAlldocuments()
        {
            var result = await _service.GetAllDocuments();
            if (result.IsError)
            {
                return BadRequest(result.FirstError);
            }

            return Ok(result.Value);
        }


    }
}
