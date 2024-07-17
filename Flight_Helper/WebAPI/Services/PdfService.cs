using PdfSharp.Drawing;
using PdfSharp.Pdf;
using WebAPI.DTO;



namespace WebAPI.Services
{

    public interface IPdfService
    {
        byte[] GenerateTripPdf(TripDTO trip);
    }

    public class PdfService : IPdfService
    {
        public byte[] GenerateTripPdf(TripDTO trip)
        {
            using (var memoryStream = new MemoryStream())
            {
                // Create a new PDF document
                PdfDocument pdf = new PdfDocument();

                // Add a page to the document
                PdfPage page = pdf.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Sample PDF content creation
                XFont font = new XFont("Verdana", 20, XFontStyleEx.Bold);
                gfx.DrawString($"Trip Name: {trip.TripName}", font, XBrushes.Black, new XRect(0, 0, page.Width.Point, 30), XStringFormats.TopLeft);

                // Add more content as needed
                gfx.DrawString($"Start Date: {trip.StartDate.ToString("yyyy-MM-dd")}", font, XBrushes.Black, new XRect(0, 40, page.Width.Point, 30), XStringFormats.TopLeft);
                gfx.DrawString($"End Date: {trip.EndDate.ToString("yyyy-MM-dd")}", font, XBrushes.Black, new XRect(0, 80, page.Width.Point, 30), XStringFormats.TopLeft);

                // Save the PDF document to memory stream
                pdf.Save(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }

}
