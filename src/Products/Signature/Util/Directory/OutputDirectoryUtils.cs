using GroupDocs.Signature.MVC.Products.Signature.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupDocs.Signature.MVC.Products.Signature.Util.Directory
{
    /// <summary>
    /// OutputDirectoryUtils
    /// </summary>
    public class OutputDirectoryUtils : IDirectoryUtils
    {
        private String OUTPUT_FOLDER = "/Output";
        private SignatureConfiguration signatureConfiguration;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="signatureConfiguration">SignatureConfiguration</param>
        public OutputDirectoryUtils(SignatureConfiguration signatureConfiguration)
        {
            this.signatureConfiguration = signatureConfiguration;

            // create output directories
            if (String.IsNullOrEmpty(signatureConfiguration.OutputDirectory))
            {
                signatureConfiguration.OutputDirectory = signatureConfiguration.FilesDirectory + OUTPUT_FOLDER;
            }
        }

        /// <summary>
        /// Get path
        /// </summary>
        /// <returns>string</returns>
        public string GetPath()
        {
            return signatureConfiguration.OutputDirectory;
        }
    }
}