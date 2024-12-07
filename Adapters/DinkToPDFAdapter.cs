using DinkToPdf;
using DinkToPdf.Contracts;

namespace teste.Adapters
{
    public class DinkToPDFAdapter : PDFAdapter
    {
        private IConverter _converter;

        public DinkToPDFAdapter(IConverter converter)
        {
            _converter = converter;
        }
        public byte[] Generate(string content)
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
                        HtmlContent = content,
                    }
                }
            };

            byte[] pdf = _converter.Convert(pdfDocument);

            return pdf;
        }
    }
}