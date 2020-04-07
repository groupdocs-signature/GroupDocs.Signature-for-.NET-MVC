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
            TextSignOptions signOptions = new TextSignOptions(textData.text);
            SetOptions(signOptions);
            // specify extended appearance options
            Options.Appearances.PdfTextAnnotationAppearance appearance = new Options.Appearances.PdfTextAnnotationAppearance();
            signOptions.Appearance = appearance;
            signOptions.SignatureImplementation = TextSignatureImplementation.Image;
            return signOptions;
        }

        /// <summary>
        /// Add image signature data
        /// </summary>
        /// <returns>SignOptions</returns>
        public override SignOptions SignImage()
        {
            return SignWord();
        }

        /// <summary>
        /// Add word signature data
        /// </summary>
        /// <returns>SignOptions</returns>
        public override SignOptions SignWord()
        {
            TextSignOptions signOptions = new TextSignOptions(textData.text);
            SetOptions(signOptions);
            signOptions.SignatureImplementation = TextSignatureImplementation.Image;
            return signOptions;
        }

        /// <summary>
        /// Add cells signature data
        /// </summary>
        /// <returns>SignOptions</returns>
        public override SignOptions SignCells()
        {
            return SignWord();
        }

        /// <summary>
        /// Add slides signature data
        /// </summary>
        /// <returns>SignOptions</returns>
        public override SignOptions SignSlides()
        {
            return SignWord();
        }

        private void SetOptions(TextSignOptions signOptions)
        {
            signOptions.Left = Convert.ToInt32(signatureData.Left);
            signOptions.Top = Convert.ToInt32(signatureData.Top);
            signOptions.Height = Convert.ToInt32(signatureData.ImageHeight);
            signOptions.Width = Convert.ToInt32(signatureData.ImageWidth);
            signOptions.RotationAngle = signatureData.Angle;
            signOptions.PageNumber = signatureData.PageNumber;
            signOptions.VerticalAlignment = VerticalAlignment.None;
            signOptions.HorizontalAlignment = HorizontalAlignment.None;
            // setup colors settings
            signOptions.Background.Color = getColor(textData.backgroundColor);
            // setup text color
            signOptions.ForeColor = getColor(textData.fontColor);
            // setup Font options
            signOptions.Font.Bold = textData.bold;
            signOptions.Font.Italic = textData.italic;
            signOptions.Font.Underline = textData.underline;
            signOptions.Font.FamilyName = textData.font;
            signOptions.Font.Size = textData.fontSize;
        }
    }
}