using System.IO;
using System.Threading.Tasks;
using Armory.Armament.Weapons.Domain;
using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using QRCoder;

namespace Armory.Armament.Weapons.Application.GenerateQR
{
    public class WeaponQrGenerator
    {
        private readonly IWeaponsRepository _repository;

        public WeaponQrGenerator(IWeaponsRepository repository)
        {
            _repository = repository;
        }

        public async Task<MemoryStream> Generate(string weaponSerial)
        {
            var weapon = await _repository.Find(weaponSerial);
            if (weapon == null)
            {
                throw new WeaponNotFound();
            }

            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(weapon.Serial, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new PngByteQRCode(qrCodeData);
            var qrBytes = qrCode.GetGraphic(20);

            var stream = new MemoryStream();
            var pdfWriter = new PdfWriter(stream);
            pdfWriter.SetCloseStream(false);
            var pdfDocument = new PdfDocument(pdfWriter);
            var document = new Document(pdfDocument);

            var imageData = ImageDataFactory.Create(qrBytes);
            var image = new Image(imageData);
            document.Add(image);
            document.Add(new Paragraph($"{weapon.Model}{weapon.Serial}"));

            document.Close();

            return stream;
        }
    }
}
