using System;
using System.Collections.Specialized;
using System.Configuration;

namespace GroupDocs.Signature.MVC.Products.Signature.Config
{
    /// <summary>
    /// SignatureConfiguration
    /// </summary>
    public class SignatureConfiguration : ConfigurationSection
    {
        public string FilesDirectory { get; set; }
        public string OutputDirectory { get; set; }
        public string DefaultDocument { get; set; }
        public string DataDirectory { get; set; }
        public int PreloadPageCount { get; set; }
        public bool isTextSignature { get; set; }
        public bool isImageSignature { get; set; }
        public bool isDigitalSignature { get; set; }
        public bool isQrCodeSignature { get; set; }
        public bool isBarCodeSignature { get; set; }
        public bool isStampSignature { get; set; }
        public bool isDownloadOriginal { get; set; }
        public bool isDownloadSigned { get; set; }
        private NameValueCollection signatureConfiguration = (NameValueCollection)System.Configuration.ConfigurationManager.GetSection("signatureConfiguration");

        /// <summary>
        /// Get signature configuration section from the Web.config
        /// </summary>
        public SignatureConfiguration()
        {
            FilesDirectory = signatureConfiguration["filesDirectory"];
            OutputDirectory = signatureConfiguration["outputDirectory"];
            DataDirectory = signatureConfiguration["dataDirectory"];
            isTextSignature = Convert.ToBoolean(signatureConfiguration["isTextSignature"]);
            isImageSignature = Convert.ToBoolean(signatureConfiguration["isImageSignature"]);
            isDigitalSignature = Convert.ToBoolean(signatureConfiguration["isDigitalSignature"]);
            isQrCodeSignature = Convert.ToBoolean(signatureConfiguration["isQrCodeSignature"]);
            isBarCodeSignature = Convert.ToBoolean(signatureConfiguration["isBarCodeSignature"]);
            isStampSignature = Convert.ToBoolean(signatureConfiguration["isStampSignature"]);
            isDownloadOriginal = Convert.ToBoolean(signatureConfiguration["isDownloadOriginal"]);
            isDownloadSigned = Convert.ToBoolean(signatureConfiguration["isDownloadSigned"]);
            DefaultDocument = signatureConfiguration["defaultDocument"];
            PreloadPageCount = Convert.ToInt32(signatureConfiguration["preloadPageCount"]);
        }
    }
}