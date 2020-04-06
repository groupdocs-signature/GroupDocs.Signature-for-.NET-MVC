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
            ImageSignOptions signOptions = new ImageSignOptions(signatureData.SignatureGuid);
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
            ImageSignOptions signOptions = new ImageSignOptions(signatureData.SignatureGuid);
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
            ImageSignOptions signOptions = new ImageSignOptions(signatureData.SignatureGuid);
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
            ImageSignOptions signOptions = new ImageSignOptions(signatureData.SignatureGuid);
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
            ImageSignOptions signOptions = new ImageSignOptions(signatureData.SignatureGuid);
            SetOptions(signOptions);
            return signOptions;
        }

        private void SetOptions(ImageSignOptions signOptions)
        {
            signOptions.Left = Convert.ToInt32(signatureData.Left);
            signOptions.Top = Convert.ToInt32(signatureData.Top);
            signOptions.Width = Convert.ToInt32(signatureData.ImageWidth);
            signOptions.Height = Convert.ToInt32(signatureData.ImageHeight);
            signOptions.PageNumber = signatureData.PageNumber;
            signOptions.RotationAngle = signatureData.Angle;
        }
    }
}