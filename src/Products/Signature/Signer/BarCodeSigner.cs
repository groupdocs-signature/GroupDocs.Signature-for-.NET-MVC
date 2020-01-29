using System;
using GroupDocs.Signature.Domain;
using GroupDocs.Signature.Options;
using GroupDocs.Signature.MVC.Products.Signature.Entity.Web;
using GroupDocs.Signature.MVC.Products.Signature.Entity.Xml;

namespace GroupDocs.Signature.MVC.Products.Signature.Signer
{
    /// <summary>
    /// BarCodeSigner
    /// </summary>
    public class BarCodeSigner : BaseSigner
    {
        private OpticalXmlEntity QrCodeData;       

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="qrCodeData">OpticalXmlEntity</param>
        /// <param name="signatureData">SignatureDataEntity</param>
        public BarCodeSigner(OpticalXmlEntity qrCodeData, SignatureDataEntity signatureData)
                : base(signatureData)
        {
            QrCodeData = qrCodeData;
        }

        /// <summary>
        /// Add signature data for pdf document
        /// </summary>
        /// <returns>SignOptions</returns>
        public override SignOptions SignPdf()
        {
            // setup options
            PdfBarcodeSignOptions signOptions = new PdfBarcodeSignOptions(QrCodeData.text);
            SetOptions(signOptions);                     
            return signOptions;
        }

        

        /// <summary>
        /// Add signature data for image file
        /// </summary>
        /// <returns>SignOptions</returns>
        public override SignOptions SignImage()
        {
            // setup options
            ImagesBarcodeSignOptions signOptions = new ImagesBarcodeSignOptions(QrCodeData.text);
            SetOptions(signOptions);
            return signOptions;
        }

        /// <summary>
        /// Add signature data for word document
        /// </summary>
        /// <returns>SignOptions</returns>
        public override SignOptions SignWord()
        {
            // setup options
            WordsBarcodeSignOptions signOptions = new WordsBarcodeSignOptions(QrCodeData.text);
            SetOptions(signOptions);
            return signOptions;
        }

        /// <summary>
        /// Add signature data for cells document
        /// </summary>
        /// <returns>SignOptions</returns>
        public override SignOptions SignCells()
        {
            // setup options
            CellsBarcodeSignOptions signOptions = new CellsBarcodeSignOptions(QrCodeData.text);
            SetOptions(signOptions);
            return signOptions;
        }

        /// <summary>
        /// Add signature data for slides document
        /// </summary>
        /// <returns>SignOptions</returns>
        public override SignOptions SignSlides()
        {
            // setup options
            SlidesBarcodeSignOptions signOptions = new SlidesBarcodeSignOptions(QrCodeData.text);
            SetOptions(signOptions);
            return signOptions;
        }

        private void SetOptions(BarcodeSignOptions signOptions)
        {
            signOptions.EncodeType = BarcodeTypes.Code39Standard;
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