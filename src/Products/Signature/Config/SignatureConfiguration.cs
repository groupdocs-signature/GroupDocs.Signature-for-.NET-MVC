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
        public string FilesDirectory;
        public string OutputDirectory;
        public string DataDirectory;
        public bool isTextSignature;
        public bool isImageSignature;
        public bool isDigitalSignature;
        public bool isQrCodeSignature;
        public bool isBarCodeSignature;
        public bool isStampSignature;
        public bool isDownloadOriginal;
        public bool isDownloadSigned;
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
        }
    }
}