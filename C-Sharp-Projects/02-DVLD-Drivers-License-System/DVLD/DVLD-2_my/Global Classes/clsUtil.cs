using System;
using System.IO;
using System.Windows.Forms;


namespace DVLD_2_my.Global_Classes
{
    public class clsUtil
    {
        static public string GenerateGUID()
        {
            Guid newFileName = Guid.NewGuid();
            return newFileName.ToString();
        }

        static public string GetFileExtensionInfo(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return "";

            FileInfo sourcefileInfo = new FileInfo(fileName);
            return sourcefileInfo.Extension;
        }

        static public string ReplacefileNameWithGuid(string sourceFile)
        {
            string newFileWithGuid = GenerateGUID() + GetFileExtensionInfo(sourceFile);
            return newFileWithGuid;
        }

        static public bool CreateFolderIfNotExist(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                try
                {
                    Directory.CreateDirectory(folderPath);
                    return true;
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error creating folder: " + err.Message);
                    return false;
                }
            }
            return true;
        }

        static public bool CopyFileToProjectFolder(ref string sourceFile)
        {

            string destinationFolder = @"D:\my-DVLD-People-Images\";
            if (!CreateFolderIfNotExist(destinationFolder))
            {
                return false;
            }

            string destinationFile = destinationFolder + ReplacefileNameWithGuid(sourceFile);
            try
            {
                File.Copy(sourceFile, destinationFile, true);
            }
            catch (IOException err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            sourceFile = destinationFile;
            return true;
        }

    }
}
