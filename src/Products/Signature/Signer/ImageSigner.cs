using System;
using GroupDocs.Signature.Options;
using GroupDocs.Signature.MVC.Products.Signature.Entity.Web;

namespace GroupDocs.Signature.MVC.Products.Signature.Signer
{
    /// <summary>
    /// ImageSigner
    /// </summary>
    public class ImageSigner : BaseSigner
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="signatureData">SignatureDataEntity</param>
        public ImageSigner(SignatureDataEntity signatureData)
                : base(signatureData)
        {

        }

        /// <summary>
        /// Add pdf signature options
        /// </summary>
        /// <returns>SignOptions</returns>
        public override SignOptions SignPdf()
        {
            // setup options
            // setup image signature options
            PdfSignImageOptions signOptions = new PdfSignImageOptions(signatureData.SignatureGuid);
            SetOptions(signOptions);
            return signOptions;
        }

        /// <summary>
        /// Add image signature options
        /// </summary>
        /// <returns>SignOptions</returns>
        public override SignOptions SignImage()
        {
            // setup image signature options with relative path - image file stores in config.ImagesPath folder
            ImagesSignImageOptions signOptions = new ImagesSignImageOptions(signatureData.SignatureGuid);
            SetOptions(signOptions);
            return signOptions;
        }

        /// <summary>
        /// Add word signature options
        /// </summary>
        /// <returns>SignOptions</returns>
        public override SignOptions SignWord()
        {
            // setup image signature options with relative path - image file stores in config.ImagesPath folder
            WordsSignImageOptions signOptions = new WordsSignImageOptions(signatureData.SignatureGuid);
            SetOptions(signOptions);
            return signOptions;
        }

        /// <summary>
        /// Add cells signature options
        /// </summary>
        /// <returns>SignOptions</returns>
        public override SignOptions SignCells()
        {
            // setup image signature options
            CellsSignImageOptions signOptions = new CellsSignImageOptions(signatureData.SignatureGuid);
            SetOptions(signOptions);
            return signOptions;
        }

        /// <summary>
        /// Add slides signature options
        /// </summary>
        /// <returns>SignOptions</returns>
        public override SignOptions SignSlides()
        {
            // setup image signature options with relative path - image file stores in config.ImagesPath folder
            SlidesSignImageOptions signOptions = new SlidesSignImageOptions(signatureData.SignatureGuid);
            SetOptions(signOptions);            
            return signOptions;
        }

        private void SetOptions(SignImageOptions signOptions)
        {
            signOptions.Left = signatureData.Left;
            signOptions.Top = signatureData.Top;
            signOptions.Width = signatureData.ImageWidth;
            signOptions.Height = signatureData.ImageHeight;
            signOptions.DocumentPageNumber = signatureData.PageNumber;
            signOptions.RotationAngle = signatureData.Angle;
        }
    }
}