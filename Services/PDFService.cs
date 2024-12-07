using System.Web;
using teste.Adapters;

namespace teste.Services
{
    public class PDFService
    {
        private PDFAdapter _pdfAdapter;

        public PDFService(PDFAdapter pdfAdapter)
        {
            _pdfAdapter = pdfAdapter;
        }

        public byte[] CreatePDF(string name)
        {
            var sanitizedString = HttpUtility.HtmlEncode(name);
            var htmlContent = $"<h1>Hello, {sanitizedString}!</h1>";

            return _pdfAdapter.Generate(htmlContent);
        }
    }

}