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
            signOptions.SignatureImplementation = PdfTextSignatureImplementation.Image;
            // setup Font options
            signOptions.Font.Bold = textData.bold;
            signOptions.Font.Italic = textData.italic;
            signOptions.Font.Underline = textData.underline;
            signOptions.Font.FontFamily = textData.font;
            // set reduction size - required to recalculate Text resizing in the UI
            int reductionSize = 0;
            // check if reduction size is between 1 and 2. for example: 1.25
            if ((double)textData.height / signatureData.ImageHeight > 1 && (double)textData.height / signatureData.ImageHeight < 2)
            {
                reductionSize = 2;
            }
            else if (textData.height / signatureData.ImageHeight == 0)
            {
                reductionSize = 1;
            }
            else
            {
                reductionSize = textData.height / signatureData.ImageHeight;
            }
            signOptions.Font.FontSize = textData.fontSize / reductionSize;
            // specify extended appearance options
            PdfTextAnnotationAppearance appearance = new PdfTextAnnotationAppearance();
            appearance.BorderColor = getColor(textData.borderColor);
            appearance.BorderStyle = (PdfTextAnnotationBorderStyle)textData.borderStyle;
            appearance.BorderWidth = textData.borderWidth;
            signOptions.Appearance = appearance;
            return signOptions;
        }

        /// <summary>
        /// Add image signature data
        /// </summary>
        /// <returns>SignOptions</returns>
        public override SignOptions SignImage()
        {
            ImagesSignTextOptions signOptions = new ImagesSignTextOptions(textData.text);
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
            signOptions.SignatureImplementation = ImagesTextSignatureImplementation.TextAsImage;
            // setup Font options
            signOptions.Font.Bold = textData.bold;
            signOptions.Font.Italic = textData.italic;
            signOptions.Font.Underline = textData.underline;
            signOptions.Font.FontFamily = textData.font;
            // set reduction size - required to recalculate Text resizing in the UI
            int reductionSize = 0;
            // check if reduction size is between 1 and 2. for example: 1.25
            if ((double)textData.height / signatureData.ImageHeight > 1 && (double)textData.height / signatureData.ImageHeight < 2)
            {
                reductionSize = 2;
            }
            else if (textData.height / signatureData.ImageHeight == 0)
            {
                reductionSize = 1;
            }
            else
            {
                reductionSize = textData.height / signatureData.ImageHeight;
            }
            signOptions.Font.FontSize = textData.fontSize / reductionSize;
            signOptions.BorderColor = getColor(textData.borderColor);
            signOptions.BorderDashStyle = (ExtendedDashStyle)textData.borderStyle;
            signOptions.BorderWeight = textData.borderWidth;

            return signOptions;
        }

        /// <summary>
        /// Add word signature data
        /// </summary>
        /// <returns>SignOptions</returns>
        public override SignOptions SignWord()
        {
            WordsSignTextOptions signOptions = new WordsSignTextOptions(textData.text);
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
            signOptions.SignatureImplementation = WordsTextSignatureImplementation.TextAsImage;
            // setup Font options
            signOptions.Font.Bold = textData.bold;
            signOptions.Font.Italic = textData.italic;
            signOptions.Font.Underline = textData.underline;
            signOptions.Font.FontFamily = textData.font;
            // set reduction size - required to recalculate Text resizing in the UI
            int reductionSize = 0;
            // check if reduction size is between 1 and 2. for example: 1.25
            if ((double)textData.height / signatureData.ImageHeight > 1 && (double)textData.height / signatureData.ImageHeight < 2)
            {
                reductionSize = 2;
            }
            else if (textData.height / signatureData.ImageHeight == 0)
            {
                reductionSize = 1;
            }
            else
            {
                reductionSize = textData.height / signatureData.ImageHeight;
            }
            signOptions.Font.FontSize = textData.fontSize / reductionSize;
            signOptions.BorderColor = getColor(textData.borderColor);
            signOptions.BorderDashStyle = (ExtendedDashStyle)textData.borderStyle;
            signOptions.BorderWeight = textData.borderWidth;
            return signOptions;
        }

        /// <summary>
        /// Add cells signature data
        /// </summary>
        /// <returns>SignOptions</returns>
        public override SignOptions SignCells()
        {
            CellsSignTextOptions signOptions = new CellsSignTextOptions(textData.text);
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
            signOptions.SignatureImplementation = CellsTextSignatureImplementation.TextAsImage;
            // setup Font options
            signOptions.Font.Bold = textData.bold;
            signOptions.Font.Italic = textData.italic;
            signOptions.Font.Underline = textData.underline;
            signOptions.Font.FontFamily = textData.font;
            // set reduction size - required to recalculate Text resizing in the UI
            int reductionSize = 0;
            // check if reduction size is between 1 and 2. for example: 1.25
            if ((double)textData.height / signatureData.ImageHeight > 1 && (double)textData.height / signatureData.ImageHeight < 2)
            {
                reductionSize = 2;
            }
            else if (textData.height / signatureData.ImageHeight == 0)
            {
                reductionSize = 1;
            }
            else
            {
                reductionSize = textData.height / signatureData.ImageHeight;
            }
            signOptions.Font.FontSize = textData.fontSize / reductionSize;
            signOptions.BorderColor = getColor(textData.borderColor);
            signOptions.BorderDashStyle = (DashStyle)textData.borderStyle;
            signOptions.BorderWeight = textData.borderWidth;
            signOptions.BorderVisiblity = true;
            return signOptions;
        }

        /// <summary>
        /// Add slides signature data
        /// </summary>
        /// <returns>SignOptions</returns>
        public override SignOptions SignSlides()
        {
            SlidesSignTextOptions signOptions = new SlidesSignTextOptions(textData.text);
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
            signOptions.SignatureImplementation = SlidesTextSignatureImplementation.TextAsImage;
            // setup Font options
            signOptions.Font.Bold = textData.bold;
            signOptions.Font.Italic = textData.italic;
            signOptions.Font.Underline = textData.underline;
            signOptions.Font.FontFamily = textData.font;
            // set reduction size - required to recalculate Text resizing in the UI
            int reductionSize = 0;
            // check if reduction size is between 1 and 2. for example: 1.25
            if ((double)textData.height / signatureData.ImageHeight > 1 && (double)textData.height / signatureData.ImageHeight < 2)
            {
                reductionSize = 2;
            }
            else if (textData.height / signatureData.ImageHeight == 0)
            {
                reductionSize = 1;
            }
            else
            {
                reductionSize = textData.height / signatureData.ImageHeight;
            }
            signOptions.Font.FontSize = textData.fontSize / reductionSize;
            signOptions.BorderColor = getColor(textData.borderColor);
            signOptions.BorderWeight = textData.borderWidth;
            return signOptions;
        }
    }
}