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
            PdfSignImageOptions pdfSignOptions = new PdfSignImageOptions(signatureData.SignatureGuid);
            // image position
            pdfSignOptions.Left = signatureData.Left;
            pdfSignOptions.Top = signatureData.Top;
            pdfSignOptions.Width = signatureData.ImageWidth;
            pdfSignOptions.Height = signatureData.ImageHeight;
            pdfSignOptions.DocumentPageNumber = signatureData.PageNumber;
            pdfSignOptions.RotationAngle = signatureData.Angle;
            return pdfSignOptions;
        }

        /// <summary>
        /// Add image signature options
        /// </summary>
        /// <returns>SignOptions</returns>
        public override SignOptions SignImage()
        {
            // setup image signature options with relative path - image file stores in config.ImagesPath folder
            ImagesSignImageOptions imageSignOptions = new ImagesSignImageOptions(signatureData.SignatureGuid);
            imageSignOptions.Left = signatureData.Left;
            imageSignOptions.Top = signatureData.Top;
            imageSignOptions.Width = signatureData.ImageWidth;
            imageSignOptions.Height = signatureData.ImageHeight;
            imageSignOptions.DocumentPageNumber = signatureData.PageNumber;
            imageSignOptions.RotationAngle = signatureData.Angle;
            return imageSignOptions;
        }

        /// <summary>
        /// Add word signature options
        /// </summary>
        /// <returns>SignOptions</returns>
        public override SignOptions SignWord()
        {
            // setup image signature options with relative path - image file stores in config.ImagesPath folder
            WordsSignImageOptions wordsSignOptions = new WordsSignImageOptions(signatureData.SignatureGuid);
            wordsSignOptions.Left = signatureData.Left;
            wordsSignOptions.Top = signatureData.Top;
            wordsSignOptions.Width = signatureData.ImageWidth;
            wordsSignOptions.Height = signatureData.ImageHeight;
            wordsSignOptions.DocumentPageNumber = signatureData.PageNumber;
            wordsSignOptions.RotationAngle = signatureData.Angle;
            return wordsSignOptions;
        }

        /// <summary>
        /// Add cells signature options
        /// </summary>
        /// <returns>SignOptions</returns>
        public override SignOptions SignCells()
        {
            // setup image signature options
            CellsSignImageOptions cellsSignOptions = new CellsSignImageOptions(signatureData.SignatureGuid);
            // image position
            cellsSignOptions.Left = signatureData.Left;
            cellsSignOptions.Top = signatureData.Top;
            cellsSignOptions.Width = signatureData.ImageWidth;
            cellsSignOptions.Height = signatureData.ImageHeight;
            cellsSignOptions.DocumentPageNumber = signatureData.PageNumber;
            cellsSignOptions.RotationAngle = signatureData.Angle;
            return cellsSignOptions;
        }

        /// <summary>
        /// Add slides signature options
        /// </summary>
        /// <returns>SignOptions</returns>
        public override SignOptions SignSlides()
        {
            // setup image signature options with relative path - image file stores in config.ImagesPath folder
            SlidesSignImageOptions slidesSignOptions = new SlidesSignImageOptions(signatureData.SignatureGuid);
            slidesSignOptions.Left = signatureData.Left;
            slidesSignOptions.Top = signatureData.Top;
            slidesSignOptions.Width = signatureData.ImageWidth;
            slidesSignOptions.Height = signatureData.ImageHeight;
            slidesSignOptions.DocumentPageNumber = signatureData.PageNumber;
            slidesSignOptions.RotationAngle = signatureData.Angle;
            return slidesSignOptions;
        }
    }
}