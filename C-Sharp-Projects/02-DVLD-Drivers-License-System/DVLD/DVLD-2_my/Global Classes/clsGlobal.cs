using Business;
using System;
using System.IO;
using System.Windows.Forms;


namespace DVLD_2_my
{

    internal static class clsGlobal
    {
        public static clsUser currentUser;

        public static bool RememberUserCredentials(string username, string password)
        {

            try
            {
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();
                string fullFilePath = currentDirectory + "\\data.txt";

                if (username == "" && File.Exists(fullFilePath))
                {
                    File.Delete(fullFilePath);
                    return true;
                }

                string dataToSave = username + "#//#" + password;

                using (StreamWriter writer = new StreamWriter(fullFilePath, false))
                {
                    writer.WriteLine(dataToSave);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error accured ", ex.Message);
                return false;
            }

        }

        public static bool GetUserStoredCredentials(ref string userName, ref string password)
        {
            try
            {
                string currentFolderPath = System.IO.Directory.GetCurrentDirectory();
                string filePath = currentFolderPath + @"\data.txt";

                if (File.Exists(filePath))
                {
                    using (StreamReader dataFileReader = new StreamReader(filePath))
                    {
                        string txt;
                        while ((txt = dataFileReader.ReadLine()) != null)
                        {
                            string[] subString = txt.Split(new string[] { "#//#" }, StringSplitOptions.None);

                            if (subString.Length != 2)
                                return false;

                            userName = subString[0];
                            password = subString[1];
                        }

                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }

        }

    }

}
