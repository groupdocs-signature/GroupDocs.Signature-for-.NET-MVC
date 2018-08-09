using GroupDocs.Signature.MVC.Products.Signature.Config;

namespace GroupDocs.Signature.MVC.Products.Signature.Util.Directory
{
    /// <summary>
    /// DirectoryUtils
    /// </summary>
    public class DirectoryUtils
    {
        public FilesDirectoryUtils FilesDirectory;
        public OutputDirectoryUtils OutputDirectory;
        public DataDirectoryUtils DataDirectory;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="signatureConfiguration">SignatureConfiguration</param>
        public DirectoryUtils(SignatureConfiguration signatureConfiguration)
        {
            FilesDirectory = new FilesDirectoryUtils(signatureConfiguration);
            OutputDirectory = new OutputDirectoryUtils(signatureConfiguration);
            DataDirectory = new DataDirectoryUtils(signatureConfiguration);
        }
    }
}