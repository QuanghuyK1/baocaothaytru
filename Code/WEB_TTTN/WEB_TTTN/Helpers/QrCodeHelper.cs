using System.Drawing;
using System.Drawing.Imaging;
using System.Net;

namespace WEB_TTTN.Helpers
{
    public class QrCodeHelper
    {
        public static Bitmap GenerateQrCode(string content)
        {
            int width = 300; int height = 300;
            string apiBaseUrl = "https://chart.googleapis.com/chart";
            string apiUrl = $"{apiBaseUrl}?cht=qr&chs={width}x{height}&chl={content}";

            using (WebClient webClient = new WebClient())
            {
                byte[] qrCodeData = webClient.DownloadData(apiUrl);
                using (MemoryStream stream = new MemoryStream(qrCodeData))
                {
                    return new Bitmap(stream);
                }
            }
        }
    }
}