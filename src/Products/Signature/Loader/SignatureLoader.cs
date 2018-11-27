using GroupDocs.Signature.MVC.Products.Common.Util.Comparator;
using GroupDocs.Signature.MVC.Products.Signature.Entity.Web;
using System;
using System.Collections.Generic;
using System.IO;

namespace GroupDocs.Signature.MVC.Products.Signature.Loader
{
    /// <summary>
    /// SignatureLoader
    /// </summary>
    public class SignatureLoader
    {
        public string CurrentPath;
        public Common.Config.GlobalConfiguration globalConfiguration;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="path">string</param>
        /// <param name="globalConfiguration">Common.Config.GlobalConfiguration</param>
        public SignatureLoader(string path, Common.Config.GlobalConfiguration globalConfiguration)
        {
            CurrentPath = path;
            this.globalConfiguration = globalConfiguration;
        }

        /// <summary>
        /// Load image signatures
        /// </summary>
        /// <returns>List[SignatureFileDescriptionEntity]</returns>
        public List<SignatureFileDescriptionEntity> LoadImageSignatures()
        {
            string[] files = Directory.GetFiles(CurrentPath, "*.*", SearchOption.AllDirectories);
            List<string> allFiles = new List<string>(files);
            List<SignatureFileDescriptionEntity> fileList = new List<SignatureFileDescriptionEntity>();
            try
            {
                allFiles.Sort(new FileTypeComparator());
                allFiles.Sort(new FileNameComparator());

                foreach (string file in allFiles)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    // check if current file/folder is hidden
                    if (fileInfo.Attributes.HasFlag(FileAttributes.Hidden) || file.Equals(globalConfiguration.Signature.DataDirectory))
                    {
                        // ignore current file and skip to next one
                        continue;
                    }
                    else
                    {
                        SignatureFileDescriptionEntity fileDescription = new SignatureFileDescriptionEntity();
                        fileDescription.guid = Path.GetFullPath(file);
                        fileDescription.name = Path.GetFileName(file);
                        // set is directory true/false
                        fileDescription.isDirectory = fileInfo.Attributes.HasFlag(FileAttributes.Directory);
                        // set file size
                        fileDescription.size = fileInfo.Length;
                        // get image Base64 incoded string
                        byte[] imageArray = File.ReadAllBytes(file);
                        string base64ImageRepresentation = Convert.ToBase64String(imageArray);
                        fileDescription.image = base64ImageRepresentation;
                        // add object to array list
                        fileList.Add(fileDescription);
                    }
                }
                return fileList;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Load digital signatures or documents
        /// </summary>
        /// <returns>List[SignatureFileDescriptionEntity]</returns>
        public List<SignatureFileDescriptionEntity> LoadFiles()
        {
            List<string> allFiles = new List<string>(Directory.GetFiles(CurrentPath));
            allFiles.AddRange(Directory.GetDirectories(CurrentPath));           
            List<SignatureFileDescriptionEntity> fileList = new List<SignatureFileDescriptionEntity>();
            try
            {                
                allFiles.Sort(new FileNameComparator());
                allFiles.Sort(new FileTypeComparator());

                foreach (string file in allFiles)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    // check if current file/folder is hidden
                    if (fileInfo.Attributes.HasFlag(FileAttributes.Hidden) || Path.GetFileName(file).Equals(Path.GetFileName(globalConfiguration.Signature.DataDirectory)))
                    {
                        // ignore current file and skip to next one
                        continue;
                    }
                    else
                    {
                        SignatureFileDescriptionEntity fileDescription = new SignatureFileDescriptionEntity();
                        fileDescription.guid = Path.GetFullPath(file);
                        fileDescription.name = Path.GetFileName(file);
                        // set is directory true/false
                        fileDescription.isDirectory = fileInfo.Attributes.HasFlag(FileAttributes.Directory);
                        // set file size
                        if (!fileDescription.isDirectory)
                        {
                            fileDescription.size = fileInfo.Length;
                        }
                        // add object to array list
                        fileList.Add(fileDescription);
                    }
                }
                return fileList;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Load stamps
        /// </summary>
        /// <param name="previewFolder">string</param>
        /// <param name="xmlFolder">string</param>
        /// <returns>List[SignatureFileDescriptionEntity]</returns>
        public List<SignatureFileDescriptionEntity> LoadStampSignatures(string previewFolder, string xmlFolder)
        {
            string imagesPath = CurrentPath + previewFolder;
            string xmlPath = CurrentPath + xmlFolder;
            string[] imageFiles = Directory.GetFiles(imagesPath);
            // get all files from the directory
            List<SignatureFileDescriptionEntity> fileList = new List<SignatureFileDescriptionEntity>();
            try
            {
                if (imageFiles != null && imageFiles.Length > 0)
                {

                    FileInfo xmls = new FileInfo(xmlPath);
                    string[] xmlFiles = Directory.GetFiles(xmlPath);
                    List<String> filesList = new List<string>();                  
                    foreach (string imageFile in imageFiles)
                    {
                        foreach (string xmlFile in xmlFiles)
                        {
                            if (Path.GetFileNameWithoutExtension(xmlFile).Equals(Path.GetFileNameWithoutExtension(imageFile)))
                            {
                                filesList.Add(imageFile);
                            }
                        }
                    }
                    // sort list of files and folders
                    filesList.Sort(new FileTypeComparator());
                    filesList.Sort(new FileNameComparator());
                    foreach (string file in filesList)
                    {
                        FileInfo fileInfo = new FileInfo(file);
                        // check if current file/folder is hidden
                        if (fileInfo.Attributes.HasFlag(FileAttributes.Hidden) || file.Equals(globalConfiguration.Signature.DataDirectory))
                        {
                            // ignore current file and skip to next one
                            continue;
                        }
                        else
                        {
                            SignatureFileDescriptionEntity fileDescription = new SignatureFileDescriptionEntity();
                            fileDescription.guid = Path.GetFullPath(file);
                            fileDescription.name = Path.GetFileName(file);
                            // set is directory true/false
                            fileDescription.isDirectory = fileInfo.Attributes.HasFlag(FileAttributes.Directory);
                            // set file size
                            fileDescription.size = fileInfo.Length;
                            // get image Base64 incoded string
                            byte[] imageArray = File.ReadAllBytes(file);
                            string base64ImageRepresentation = Convert.ToBase64String(imageArray);
                            fileDescription.image = base64ImageRepresentation;
                            // add object to array list
                            fileList.Add(fileDescription);
                        }
                    }
                }
                return fileList;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}