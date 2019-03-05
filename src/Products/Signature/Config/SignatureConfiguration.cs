using GroupDocs.Signature.MVC.Products.Common.Config;
using GroupDocs.Signature.MVC.Products.Common.Util.Parser;
using System;
using System.IO;
using System.Linq;

namespace GroupDocs.Signature.MVC.Products.Signature.Config
{
    /// <summary>
    /// SignatureConfiguration
    /// </summary>
    public class SignatureConfiguration
    {
        public string FilesDirectory = "DocumentSamples/Signature";
        public string DefaultDocument = "";
        public string DataDirectory = "";
        public int PreloadPageCount = 0;
        public bool isTextSignature = true;
        public bool isImageSignature = true;
        public bool isDigitalSignature = true;
        public bool isQrCodeSignature = true;
        public bool isBarCodeSignature = true;
        public bool isStampSignature = true;
        public bool isHandSignature = true;
        public bool isDownloadOriginal = true;
        public bool isDownloadSigned = true;
        private string TempFilesDirectory = "";

        /// <summary>
        /// Get signature configuration section from the Web.config
        /// </summary>
        public SignatureConfiguration()
        {
            YamlParser parser = new YamlParser();
            dynamic configuration = parser.GetConfiguration("signature");
            ConfigurationValuesGetter valuesGetter = new ConfigurationValuesGetter(configuration);
            // get Comparison configuration section from the web.config            
            FilesDirectory = valuesGetter.GetStringPropertyValue("filesDirectory", FilesDirectory);
            if (!IsFullPath(FilesDirectory))
            {
                FilesDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FilesDirectory);
                if (!Directory.Exists(FilesDirectory))
                {
                    Directory.CreateDirectory(FilesDirectory);
                }
            }
            DataDirectory = valuesGetter.GetStringPropertyValue("dataDirectory", DataDirectory);
            DefaultDocument = valuesGetter.GetStringPropertyValue("defaultDocument", DefaultDocument);
            isTextSignature = valuesGetter.GetBooleanPropertyValue("textSignature", isTextSignature);
            isImageSignature = valuesGetter.GetBooleanPropertyValue("imageSignature", isImageSignature);
            isDigitalSignature = valuesGetter.GetBooleanPropertyValue("digitalSignature", isDigitalSignature);
            isQrCodeSignature = valuesGetter.GetBooleanPropertyValue("qrCodeSignature", isQrCodeSignature);
            isBarCodeSignature = valuesGetter.GetBooleanPropertyValue("barCodeSignature", isBarCodeSignature);
            isStampSignature = valuesGetter.GetBooleanPropertyValue("stampSignature", isStampSignature);
            isHandSignature = valuesGetter.GetBooleanPropertyValue("handSignature", isHandSignature);
            isDownloadOriginal = valuesGetter.GetBooleanPropertyValue("downloadOriginal", isDownloadOriginal);
            isDownloadSigned = valuesGetter.GetBooleanPropertyValue("downloadSigned", isDownloadSigned);
            PreloadPageCount = valuesGetter.GetIntegerPropertyValue("preloadPageCount", PreloadPageCount);
        }

        private static bool IsFullPath(string path)
        {
            return !String.IsNullOrWhiteSpace(path)
                && path.IndexOfAny(System.IO.Path.GetInvalidPathChars().ToArray()) == -1
                && Path.IsPathRooted(path)
                && !Path.GetPathRoot(path).Equals(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal);
        }

        public void SetTempFilesDirectory(string tempFilesDirectory)
        {
            this.TempFilesDirectory = tempFilesDirectory;
        }

        public string GetTempFilesDirectory()
        {
            return this.TempFilesDirectory;
        }
    }
}