using GroupDocs.Signature.MVC.Products.Signature.Config;
using GroupDocs.Signature.MVC.Products.Signature.Entity.Directory;
using System;

namespace GroupDocs.Signature.MVC.Products.Signature.Util.Directory
{
    /// <summary>
    /// DataDirectoryUtils
    /// </summary>
    public class DataDirectoryUtils : IDirectoryUtils
    {
        private string DATA_FOLDER = "/SignatureData";
        private SignatureConfiguration signatureConfiguration;

        public CertificateDataDirectoryEntity CertificateDirectory { get; set; }
        public ImageDataDirectoryEntity ImageDirectory { get; set; }
        public StampDataDirectoryEntity StampDirectory { get; set; }
        public QrCodeDataDirectoryEntity QrCodeDirectory { get; set; }
        public BarcodeDataDirectoryEntity BarcodeDirectory { get; set; }
        public TextDataDirectoryEntity TextDirectory { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="signatureConfig">SignatureConfiguration</param>
        public DataDirectoryUtils(SignatureConfiguration signatureConfig)
        {
            signatureConfiguration = signatureConfig;

            // check if data directory was set, if not set new directory
            if (String.IsNullOrEmpty(signatureConfiguration.DataDirectory))
            {
                signatureConfiguration.DataDirectory = signatureConfiguration.FilesDirectory + DATA_FOLDER;
            }

            // create directory objects
            BarcodeDirectory = new BarcodeDataDirectoryEntity(signatureConfiguration);
            CertificateDirectory = new CertificateDataDirectoryEntity(signatureConfiguration);
            ImageDirectory = new ImageDataDirectoryEntity(signatureConfiguration);
            StampDirectory = new StampDataDirectoryEntity(signatureConfiguration);
            QrCodeDirectory = new QrCodeDataDirectoryEntity(signatureConfiguration);
            BarcodeDirectory = new BarcodeDataDirectoryEntity(signatureConfiguration);
            TextDirectory = new TextDataDirectoryEntity(signatureConfiguration);

            // create directories
            System.IO.Directory.CreateDirectory(CertificateDirectory.Path);
            System.IO.Directory.CreateDirectory(ImageDirectory.Path);

            System.IO.Directory.CreateDirectory(StampDirectory.XmlPath);
            System.IO.Directory.CreateDirectory(StampDirectory.PreviewPath);

            System.IO.Directory.CreateDirectory(QrCodeDirectory.XmlPath);
            System.IO.Directory.CreateDirectory(QrCodeDirectory.PreviewPath);

            System.IO.Directory.CreateDirectory(BarcodeDirectory.XmlPath);
            System.IO.Directory.CreateDirectory(BarcodeDirectory.PreviewPath);

            System.IO.Directory.CreateDirectory(TextDirectory.XmlPath);
            System.IO.Directory.CreateDirectory(TextDirectory.PreviewPath);
        }

        /// <summary>
        /// Get path
        /// </summary>
        /// <returns>string</returns>
        public string GetPath()
        {
            return signatureConfiguration.DataDirectory;
        }
    }
}