using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using WPF_Cinema_App.Models;

namespace WPF_Cinema_App.Static_File_Helper_Classes
{
    public static class PdfFileHelper
    {
        public static void WritePaymentToFile(Tuple<Movie, double, double> movieAndPaymentAndRating, string fileName)
        {

            if (string.IsNullOrWhiteSpace(fileName) == false)
            {
                if (Directory.Exists("Payments") == false)
                {
                    Directory.CreateDirectory("Payments");
                }

                Document document = new Document(PageSize.LETTER, 40f, 40f, 60f, 60f);
                PdfWriter.GetInstance(document, new FileStream($"Payments/{fileName}.pdf", FileMode.OpenOrCreate));

                document.Open();

                Paragraph titleParagraph = new Paragraph(movieAndPaymentAndRating.Item1.TitleAndImdbRatingCombination)
                {
                    Alignment = Element.ALIGN_CENTER
                };
                document.Add(titleParagraph);

                document.Add
                (
                    new Paragraph("")
                    {
                        SpacingBefore = 40f,
                    }
                );

                SaveImage(movieAndPaymentAndRating.Item1.Poster);


                using (FileStream fs = new FileStream("Payments/temp.jpg", FileMode.Open))
                {
                    var jpeg = Image.GetInstance(System.Drawing.Image.FromStream(fs), ImageFormat.Jpeg);
                    jpeg.ScalePercent(5f);
                    jpeg.ScaleToFit(450f, 250f);
                    jpeg.SetAbsolutePosition(document.Left + 180, document.Top - 300);
                    document.Add(jpeg);
                }


                document.Add
                (
                    new Paragraph("")
                    {
                        SpacingBefore = 280f,
                    }
                );

                Paragraph paymentParagraph = new Paragraph($"Guest buys {movieAndPaymentAndRating.Item2 / movieAndPaymentAndRating.Item1.ImdbRating} tickets and pays {movieAndPaymentAndRating.Item2} $.\nGuest gave {movieAndPaymentAndRating.Item3} stars to this movie.")
                {
                    Alignment = Element.ALIGN_CENTER
                };
                document.Add(paymentParagraph);

                document.Close();

                File.Delete($"{Directory.GetCurrentDirectory()}/Payments/temp.jpg");
            }
        }

        public static string ConvertFileNameToAcceptableFileName(string fileName)
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder(fileName.Length);

            for (int i = 0; i < fileName.Length; i++)
            {
                if (fileName[i] == '/' || fileName[i] == '\\' || fileName[i] == ':' || fileName[i] == '*'
                    || fileName[i] == '?' || fileName[i] == '<' || fileName[i] == '>' || fileName[i] == '|')
                {
                    stringBuilder.Append('-');
                }
                else
                {
                    stringBuilder.Append(fileName[i]);
                }
            }

            stringBuilder.Append(' ');
            stringBuilder.Append(DateTime.Now.ToLongDateString());
            stringBuilder.Append(Guid.NewGuid());

            return stringBuilder.ToString();
        }
        private static void SaveImage(string imageUrl)
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(imageUrl);
            System.Drawing.Bitmap bitmap; bitmap = new System.Drawing.Bitmap(stream);

            bitmap?.Save($"{Directory.GetCurrentDirectory()}/Payments/temp.jpg", ImageFormat.Jpeg);

            stream.Flush();
            stream.Close();
            client.Dispose();
        }   
    }
}