using DinkToPdf;
using DinkToPdf.Contracts;

namespace teste.Services
{
    public class PDFService
    {
        private IConverter _converter;

        public PDFService(IConverter converter)
        {
            _converter = converter;
        }
        public byte[] CreatePDF(string name)
        {

            var pdfDocument = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4Plus,
                },
                Objects = {
                    new ObjectSettings()
                    {
                        HtmlContent = $"<h1>Hello, {name}!</h1>",
                    }
                }
            };

            byte[] pdf = _converter.Convert(pdfDocument);

            return pdf;
        }
    }




}