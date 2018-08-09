using GroupDocs.Signature.Options;
using GroupDocs.Signature.MVC.Products.Signature.Entity.Web;
using System;
using System.Globalization;

namespace GroupDocs.Signature.MVC.Products.Signature.Signer
{
    /// <summary>
    /// DigitalSigner
    /// </summary>
    public class DigitalSigner : BaseSigner
    {
        private string password;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="signatureData">SignatureDataEntity</param>
        /// <param name="password">string</param>
        public DigitalSigner(SignatureDataEntity signatureData, string password)
                : base(signatureData)
        {
            this.password = password;
        }

        /// <summary>
        /// Add digital signature options for pdf document
        /// </summary>
        /// <returns>SignOptions</returns>
        public override SignOptions SignPdf()
        {
            // setup digital signature options
            PdfSignDigitalOptions pdfSignOptions = new PdfSignDigitalOptions(signatureData.SignatureGuid);
            pdfSignOptions.Reason = signatureData.Reason;
            pdfSignOptions.Contact = signatureData.Contact;
            pdfSignOptions.Location = signatureData.Address;
            pdfSignOptions.Password = password;
            pdfSignOptions.SignAllPages = true;
            if (!String.IsNullOrEmpty(signatureData.Date))
            {
                pdfSignOptions.Signature.SignTime = DateTime.ParseExact(signatureData.Date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            }
            return pdfSignOptions;
        }

        /// <summary>
        /// Add digital signature options for image file
        /// </summary>
        /// <returns>SignOptions</returns>
        /// <throws>Not supported exception</throws>
        public override SignOptions SignImage()
        {
            throw new NotSupportedException("This file type is not supported");
        }

        /// <summary>
        /// Add digital signature options for word document
        /// </summary>
        /// <returns>SignOptions</returns>
        public override SignOptions SignWord()
        {
            WordsSignDigitalOptions wordsSignOptions = new WordsSignDigitalOptions(signatureData.SignatureGuid);
            wordsSignOptions.Signature.Comments = signatureData.SignatureComment;
            if (!String.IsNullOrEmpty(signatureData.Date))
            {
                wordsSignOptions.Signature.SignTime = DateTime.ParseExact(signatureData.Date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            }
            wordsSignOptions.Password = password;
            wordsSignOptions.SignAllPages = true;
            return wordsSignOptions;
        }

        /// <summary>
        /// Add digital signature options for cells document
        /// </summary>
        /// <returns>SignOptions</returns>
        public override SignOptions SignCells()
        {
            CellsSignDigitalOptions cellsSignOptions = new CellsSignDigitalOptions(signatureData.SignatureGuid);
            cellsSignOptions.Signature.Comments = signatureData.SignatureComment;
            if (!String.IsNullOrEmpty(signatureData.Date))
            {
                cellsSignOptions.Signature.SignTime = DateTime.ParseExact(signatureData.Date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            }
            cellsSignOptions.Password = password;
            cellsSignOptions.SignAllPages = true;
            return cellsSignOptions;
        }

        /// <summary>
        /// Add digital signature options for slides document
        /// </summary>
        /// <returns>SignOptions</returns>
        /// <throws>Not supported exception</throws>
        public override SignOptions SignSlides()
        {
            throw new NotSupportedException("This file type is not supported");
        }
    }
}