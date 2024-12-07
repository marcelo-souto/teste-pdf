using Microsoft.AspNetCore.Mvc;
using teste.Services;

namespace teste.Controllers
{
    [ApiController]
    [Route("api/pdf")]
    public class PDFController : ControllerBase
    {

        private readonly PDFService _pdfService;

        public PDFController(PDFService pdfService)
        {
            _pdfService = pdfService;
        }

        [HttpPost]
        public IActionResult CreatePDF([FromForm] string name)
        {
            var pdf = _pdfService.CreatePDF(name);
            return File(pdf, "application/pdf", "file.pdf");
        }

    }
}