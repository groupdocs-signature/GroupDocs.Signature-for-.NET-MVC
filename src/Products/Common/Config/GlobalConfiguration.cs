﻿using GroupDocs.Signature.MVC.Products.Signature.Config;

namespace GroupDocs.Signature.MVC.Products.Common.Config
{
    /// <summary>
    /// Global configuration
    /// </summary>
    public class GlobalConfiguration
    {
        public ServerConfiguration Server;
        public ApplicationConfiguration Application;
        public SignatureConfiguration Signature;
        public CommonConfiguration Common;

        /// <summary>
        /// Get all configurations
        /// </summary>
        public GlobalConfiguration()
        {
            Server = new ServerConfiguration();
            Application = new ApplicationConfiguration();
            Signature = new SignatureConfiguration();
            Common = new CommonConfiguration();
        }
    }
}