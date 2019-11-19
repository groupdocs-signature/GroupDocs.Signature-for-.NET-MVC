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
    public class SignatureConfiguration : CommonConfiguration
    {
        public string FilesDirectory = "DocumentSamples/Signature";
        public string DefaultDocument = "";
        public string DataDirectory = "";
        public int PreloadPageCount = 0;
        public bool textSignature = true;
        public bool imageSignature = true;
        public bool digitalSignature = true;
        public bool qrCodeSignature = true;
        public bool barCodeSignature = true;
        public bool stampSignature = true;
        public bool handSignature = true;
        public bool downloadOriginal = true;
        public bool downloadSigned = true;
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
            textSignature = valuesGetter.GetBooleanPropertyValue("textSignature", textSignature);
            imageSignature = valuesGetter.GetBooleanPropertyValue("imageSignature", imageSignature);
            digitalSignature = valuesGetter.GetBooleanPropertyValue("digitalSignature", digitalSignature);
            qrCodeSignature = valuesGetter.GetBooleanPropertyValue("qrCodeSignature", qrCodeSignature);
            barCodeSignature = valuesGetter.GetBooleanPropertyValue("barCodeSignature", barCodeSignature);
            stampSignature = valuesGetter.GetBooleanPropertyValue("stampSignature", stampSignature);
            handSignature = valuesGetter.GetBooleanPropertyValue("handSignature", handSignature);
            downloadOriginal = valuesGetter.GetBooleanPropertyValue("downloadOriginal", downloadOriginal);
            downloadSigned = valuesGetter.GetBooleanPropertyValue("downloadSigned", downloadSigned);
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