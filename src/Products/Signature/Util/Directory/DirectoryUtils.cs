using GroupDocs.Signature.MVC.Products.Signature.Config;

namespace GroupDocs.Signature.MVC.Products.Signature.Util.Directory
{
    /// <summary>
    /// DirectoryUtils
    /// </summary>
    public class DirectoryUtils
    {
        private FilesDirectoryUtils FilesDirectory;
        private DataDirectoryUtils DataDirectory;
        private TempDirectoryUtils TempFolder;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="signatureConfiguration">SignatureConfiguration</param>
        public DirectoryUtils(SignatureConfiguration signatureConfiguration)
        {
            FilesDirectory = new FilesDirectoryUtils(signatureConfiguration);
            DataDirectory = new DataDirectoryUtils(signatureConfiguration);
            TempFolder = new TempDirectoryUtils(signatureConfiguration);
        }

        public FilesDirectoryUtils GetFilesDirectory()
        {
            return FilesDirectory;
        }

        public void SetFilesDirectory(FilesDirectoryUtils filesDirectory) {
            this.FilesDirectory = filesDirectory;
        }

        public DataDirectoryUtils GetDataDirectory()
        {
            return DataDirectory;
        }

        public void SetDataDirectory(DataDirectoryUtils dataDirectory)
        {
            this.DataDirectory = dataDirectory;
        }

        public TempDirectoryUtils GetTempFolder()
        {
            return TempFolder;
        }

        public void SetTempFolder(TempDirectoryUtils tempFolder)
        {
            this.TempFolder = tempFolder;
        }
    }
}