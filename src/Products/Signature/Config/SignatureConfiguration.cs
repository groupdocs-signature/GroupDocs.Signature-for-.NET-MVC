using GroupDocs.Signature.MVC.Products.Common.Config;
using GroupDocs.Signature.MVC.Products.Common.Util.Parser;
using Newtonsoft.Json;
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
        [JsonProperty]
        public string FilesDirectory = "DocumentSamples/Signature";

        [JsonProperty]
        public string DefaultDocument = "";

        [JsonProperty]
        public string DataDirectory = "";

        [JsonProperty]
        public int PreloadPageCount;

        [JsonProperty]
        public bool textSignature = true;

        [JsonProperty]
        public bool imageSignature = true;

        [JsonProperty]
        public bool digitalSignature = true;

        [JsonProperty]
        public bool qrCodeSignature = true;

        [JsonProperty]
        public bool barCodeSignature = true;

        [JsonProperty]
        public bool stampSignature = true;

        [JsonProperty]
        public bool handSignature = true;

        [JsonProperty]
        public bool downloadOriginal = true;

        [JsonProperty]
        public bool downloadSigned = true;

        [JsonProperty]
        private string TempFilesDirectory = "";

        [JsonProperty]
        private bool zoom = true;

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
            zoom = valuesGetter.GetBooleanPropertyValue("zoom", zoom);
        }

        private static bool IsFullPath(string path)
        {
            return !String.IsNullOrWhiteSpace(path)
                && path.IndexOfAny(Path.GetInvalidPathChars().ToArray()) == -1
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