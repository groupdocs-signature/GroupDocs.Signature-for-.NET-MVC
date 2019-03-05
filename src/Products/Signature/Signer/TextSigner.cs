using System;
using GroupDocs.Signature.Domain;
using GroupDocs.Signature.Options;
using GroupDocs.Signature.MVC.Products.Signature.Entity.Web;
using GroupDocs.Signature.MVC.Products.Signature.Entity.Xml;

namespace GroupDocs.Signature.MVC.Products.Signature.Signer
{
    /// <summary>
    /// TextSigner
    /// </summary>
    public class TextSigner : BaseSigner
    {
        private TextXmlEntity textData;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="textData">TextXmlEntity</param>
        /// <param name="signatureData">SignatureDataEntity</param>
        public TextSigner(TextXmlEntity textData, SignatureDataEntity signatureData)
            : base(signatureData)
        {
            this.textData = textData;
        }

        /// <summary>
        /// Add pdf signature data
        /// </summary>
        /// <returns>SignOptions</returns>
        public override SignOptions SignPdf()
        {
            PdfSignTextOptions signOptions = new PdfSignTextOptions(textData.text);
            SetOptions(signOptions);
            // specify extended appearance options
            PdfTextAnnotationAppearance appearance = new PdfTextAnnotationAppearance();          
            signOptions.Appearance = appearance;
            signOptions.SignatureImplementation = PdfTextSignatureImplementation.Image;
            return signOptions;
        }

        /// <summary>
        /// Add image signature data
        /// </summary>
        /// <returns>SignOptions</returns>
        public override SignOptions SignImage()
        {
            ImagesSignTextOptions signOptions = new ImagesSignTextOptions(textData.text);
            SetOptions(signOptions);
            signOptions.SignatureImplementation = ImagesTextSignatureImplementation.TextAsImage;
            return signOptions;
        }

        /// <summary>
        /// Add word signature data
        /// </summary>
        /// <returns>SignOptions</returns>
        public override SignOptions SignWord()
        {
            WordsSignTextOptions signOptions = new WordsSignTextOptions(textData.text);
            SetOptions(signOptions);
            signOptions.SignatureImplementation = WordsTextSignatureImplementation.TextAsImage;
            return signOptions;
        }

        /// <summary>
        /// Add cells signature data
        /// </summary>
        /// <returns>SignOptions</returns>
        public override SignOptions SignCells()
        {
            CellsSignTextOptions signOptions = new CellsSignTextOptions(textData.text);
            SetOptions(signOptions);
            signOptions.SignatureImplementation = CellsTextSignatureImplementation.TextAsImage;
            return signOptions;
        }

        /// <summary>
        /// Add slides signature data
        /// </summary>
        /// <returns>SignOptions</returns>
        public override SignOptions SignSlides()
        {
            SlidesSignTextOptions signOptions = new SlidesSignTextOptions(textData.text);
            SetOptions(signOptions);
            signOptions.SignatureImplementation = SlidesTextSignatureImplementation.TextAsImage;
            return signOptions;
        }

        private void SetOptions(dynamic signOptions)
        {
            signOptions.Left = signatureData.Left;
            signOptions.Top = signatureData.Top;
            signOptions.Height = signatureData.ImageHeight;
            signOptions.Width = signatureData.ImageWidth;
            signOptions.RotationAngle = signatureData.Angle;
            signOptions.DocumentPageNumber = signatureData.PageNumber;
            signOptions.VerticalAlignment = VerticalAlignment.None;
            signOptions.HorizontalAlignment = HorizontalAlignment.None;
            // setup colors settings
            signOptions.BackgroundColor = getColor(textData.backgroundColor);
            // setup text color
            signOptions.ForeColor = getColor(textData.fontColor);           
            // setup Font options
            signOptions.Font.Bold = textData.bold;
            signOptions.Font.Italic = textData.italic;
            signOptions.Font.Underline = textData.underline;
            signOptions.Font.FontFamily = textData.font;           
            signOptions.Font.FontSize = textData.fontSize;
        }
    }
}