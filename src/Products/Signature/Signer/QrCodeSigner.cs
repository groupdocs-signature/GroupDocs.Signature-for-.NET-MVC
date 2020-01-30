using GroupDocs.Signature.Domain;
using GroupDocs.Signature.Options;
using GroupDocs.Signature.MVC.Products.Signature.Entity.Web;
using GroupDocs.Signature.MVC.Products.Signature.Entity.Xml;
using System;

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
            SetOptions(signOptions);
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
            SetOptions(signOptions);
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
            SetOptions(signOptions);
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
            SetOptions(signOptions);
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
            SetOptions(signOptions);
            return signOptions;
        }

        private void SetOptions(QRCodeSignOptions signOptions)
        {
            signOptions.EncodeType = QRCodeTypes.QR;
            signOptions.HorizontalAlignment = signatureData.getHorizontalAlignment();
            signOptions.VerticalAlignment = signatureData.getVerticalAlignment();
            signOptions.Width = Convert.ToInt32(signatureData.ImageWidth);           
            signOptions.Height = Convert.ToInt32(signatureData.ImageHeight);
            signOptions.Top = Convert.ToInt32(signatureData.Top);
            signOptions.Left = Convert.ToInt32(signatureData.Left);
            signOptions.DocumentPageNumber = signatureData.PageNumber;
            if (signatureData.Angle != 0)
            {
                signOptions.RotationAngle = signatureData.Angle;
            }
        }
    }
}