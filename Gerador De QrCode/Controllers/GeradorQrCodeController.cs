using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

namespace Gerador_De_QrCode.Controllers
{
    public class GeradorQrCodeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GerarQrCode()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GerarQrCode(string palavra)
        {
            if (palavra != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();
                    QRCodeData qRCodeData = qrGenerator.CreateQrCode(palavra, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qRCodeData);

                    using (Bitmap qrCodeBitmap = qrCode.GetGraphic(30))
                    {
                        qrCodeBitmap.Save(ms, ImageFormat.Png);

                        ViewBag.QrCodeImage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
            else
            {
                ViewBag.QrCodeImage = null;
            }
            return View();
        }
    }
}
