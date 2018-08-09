
using GroupDocs.Signature.Domain;
using GroupDocs.Signature.Options;
using GroupDocs.Signature.MVC.Products.Signature.Entity.Web;
using GroupDocs.Signature.MVC.Products.Signature.Entity.Xml;

namespace GroupDocs.Signature.MVC.Products.Signature.Signer
{
    /// <summary>
    /// QrCodeSigner
    /// </summary>
    public class QrCodeSigner : BaseSigner
    {
        private OpticalXmlEntity qrCodeData;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="qrCodeData">OpticalXmlEntity</param>
        /// <param name="signatureData">SignatureDataEntity</param>
        public QrCodeSigner(OpticalXmlEntity qrCodeData, SignatureDataEntity signatureData)
            : base(signatureData)
        {
            this.qrCodeData = qrCodeData;
        }

        /// <summary>
        /// Add pdf signature data
        /// </summary>
        /// <returns>SignOptions</returns>
        public override SignOptions SignPdf()
        {
            // setup options
            PdfQRCodeSignOptions signOptions = new PdfQRCodeSignOptions(qrCodeData.text);
            signOptions.EncodeType = QRCodeTypes.QR;
            signOptions.HorizontalAlignment = HorizontalAlignment.None;
            signOptions.VerticalAlignment = VerticalAlignment.None;
            signOptions.Width = signatureData.ImageWidth;
            signOptions.Height = signatureData.ImageHeight;
            signOptions.Top = signatureData.Top;
            signOptions.Left = signatureData.Left;
            signOptions.DocumentPageNumber = signatureData.PageNumber;
            signOptions.RotationAngle = signatureData.Angle;
            if (qrCodeData.borderWidth != 0)
            {
                signOptions.BorderVisiblity = true;
                signOptions.BorderColor = getColor(qrCodeData.borderColor);
                signOptions.BorderWeight = qrCodeData.borderWidth;
                signOptions.BorderDashStyle = (DashStyle)qrCodeData.borderStyle;
            }
            return signOptions;
        }

        /// <summary>
        /// Add image signature data
        /// </summary>
        /// <returns>SignOptions</returns>
        public override SignOptions SignImage()
        {
            // setup options
            ImagesQRCodeSignOptions signOptions = new ImagesQRCodeSignOptions(qrCodeData.text);
            signOptions.EncodeType = QRCodeTypes.QR;
            signOptions.HorizontalAlignment = HorizontalAlignment.None;
            signOptions.VerticalAlignment = VerticalAlignment.None;
            signOptions.Width = signatureData.ImageWidth;
            signOptions.Height = signatureData.ImageHeight;
            signOptions.Top = signatureData.Top;
            signOptions.Left = signatureData.Left;
            signOptions.DocumentPageNumber = signatureData.PageNumber;
            signOptions.RotationAngle = signatureData.Angle;
            if (qrCodeData.borderWidth != 0)
            {
                signOptions.BorderVisiblity = true;
                signOptions.BorderColor = getColor(qrCodeData.borderColor);
                signOptions.BorderWeight = qrCodeData.borderWidth;
                signOptions.BorderDashStyle = (DashStyle)qrCodeData.borderStyle;
            }
            return signOptions;
        }

        /// <summary>
        /// Add word signature data
        /// </summary>
        /// <returns>SignOptions</returns>
        public override SignOptions SignWord()
        {
            // setup options
            WordsQRCodeSignOptions signOptions = new WordsQRCodeSignOptions(qrCodeData.text);
            signOptions.EncodeType = QRCodeTypes.QR;
            signOptions.HorizontalAlignment = HorizontalAlignment.None;
            signOptions.VerticalAlignment = VerticalAlignment.None;
            signOptions.Width = signatureData.ImageWidth;
            signOptions.Height = signatureData.ImageHeight;
            signOptions.Top = signatureData.Top;
            signOptions.Left = signatureData.Left;
            signOptions.DocumentPageNumber = signatureData.PageNumber;
            signOptions.RotationAngle = signatureData.Angle;
            if (qrCodeData.borderWidth != 0)
            {
                signOptions.BorderVisiblity = true;
                signOptions.BorderColor = getColor(qrCodeData.borderColor);
                signOptions.BorderWeight = qrCodeData.borderWidth;
                signOptions.BorderDashStyle = (DashStyle)qrCodeData.borderStyle;
            }
            return signOptions;
        }

        /// <summary>
        /// Add cells signature data
        /// </summary>
        /// <returns>SignOptions</returns>
        public override SignOptions SignCells()
        {
            // setup options
            CellsQRCodeSignOptions signOptions = new CellsQRCodeSignOptions(qrCodeData.text);
            signOptions.EncodeType = QRCodeTypes.QR;
            signOptions.HorizontalAlignment = HorizontalAlignment.None;
            signOptions.VerticalAlignment = VerticalAlignment.None;
            signOptions.Width = signatureData.ImageWidth;
            signOptions.Height = signatureData.ImageHeight;
            signOptions.Top = signatureData.Top;
            signOptions.Left = signatureData.Left;
            signOptions.DocumentPageNumber = signatureData.PageNumber;
            signOptions.RotationAngle = signatureData.Angle;
            if (qrCodeData.borderWidth != 0)
            {
                signOptions.BorderVisiblity = true;
                signOptions.BorderColor = getColor(qrCodeData.borderColor);
                signOptions.BorderWeight = qrCodeData.borderWidth;
                signOptions.BorderDashStyle = (DashStyle)qrCodeData.borderStyle;
            }
            return signOptions;
        }

        /// <summary>
        /// Add slides signature data
        /// </summary>
        /// <returns>SignOptions</returns>
        public override SignOptions SignSlides()
        {
            // setup options
            SlidesQRCodeSignOptions signOptions = new SlidesQRCodeSignOptions(qrCodeData.text);
            signOptions.EncodeType = QRCodeTypes.QR;
            signOptions.HorizontalAlignment = HorizontalAlignment.None;
            signOptions.VerticalAlignment = VerticalAlignment.None;
            signOptions.Width = signatureData.ImageWidth;
            signOptions.Height = signatureData.ImageHeight;
            signOptions.Top = signatureData.Top;
            signOptions.Left = signatureData.Left;
            signOptions.DocumentPageNumber = signatureData.PageNumber;
            signOptions.RotationAngle = signatureData.Angle;
            if (qrCodeData.borderWidth != 0)
            {
                signOptions.BorderVisiblity = true;
                signOptions.BorderColor = getColor(qrCodeData.borderColor);
                signOptions.BorderWeight = qrCodeData.borderWidth;
                signOptions.BorderDashStyle = (DashStyle)qrCodeData.borderStyle;
            }
            return signOptions;
        }

    }
}