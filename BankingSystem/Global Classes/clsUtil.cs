using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingSystem
{
    public class clsUtil
    {
        public static string GenerateGUID()
        {

            // Generate a new GUID
            Guid newGuid = Guid.NewGuid();

            // convert the GUID to a string
            return newGuid.ToString();

        }

        public static bool CreateFolderIfDoesNotExist(string FolderPath)
        {

            // Check if the folder exists
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    // If it doesn't exist, create the folder
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating folder: " + ex.Message);
                    return false;
                }
            }

            return true;

        }

        public static string ReplaceFileNameWithGUID(string sourceFile)
        {
            // Full file name. Change your file name   
            string fileName = sourceFile;
            FileInfo fi = new FileInfo(fileName);
            string extn = fi.Extension;
            return GenerateGUID() + extn;

        }

        public static bool CopyImageToProjectImagesFolder(ref string sourceFile)
        {
            // this funciton will copy the image to the
            // project images foldr after renaming it
            // with GUID with the same extention, then it will update the sourceFileName with the new name.

            string DestinationFolder = @"C:\DVLD-People-Images\";
            if (!CreateFolderIfDoesNotExist(DestinationFolder))
            {
                return false;
            }

            string destinationFile = DestinationFolder + ReplaceFileNameWithGUID(sourceFile);
            try
            {
                File.Copy(sourceFile, destinationFile, true);

            }
            catch (IOException iox)
            {
                MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            sourceFile = destinationFile;
            return true;
        }

        public static string NumberToText(int number)
        {
            if (number == 0)
            {
                return "";
            }

            if (number >= 1 && number <= 19)
            {
                string[] arr = {"", "One", "Two", "Three", "Four", "Five", "Six", "Seven",
                        "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen",
                         "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"};

                return arr[number] + " ";
            }

            if (number >= 20 && number <= 99)
            {
                string[] arr = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
                return arr[number / 10] + " " + NumberToText(number % 10);
            }

            if (number >= 100 && number <= 199)
            {
                return "One Hundred " + NumberToText(number % 100);
            }

            if (number >= 200 && number <= 999)
            {
                return NumberToText(number / 100) + "Hundreds " + NumberToText(number % 100);
            }

            if (number >= 1000 && number <= 1999)
            {
                return "One Thousand " + NumberToText(number % 1000);
            }

            if (number >= 2000 && number <= 999999)
            {
                return NumberToText(number / 1000) + "Thousands " + NumberToText(number % 1000);
            }

            if (number >= 1000000 && number <= 1999999)
            {
                return "One Million " + NumberToText(number % 1000000);
            }

            if (number >= 2000000 && number <= 999999999)
            {
                return NumberToText(number / 1000000) + "Millions " + NumberToText(number % 1000000);
            }

            if (number >= 1000000000 && number <= 1999999999)
            {
                return "One Billion " + NumberToText(number % 1000000000);
            }
            else
            {
                return NumberToText(number / 1000000000) + "Billions " + NumberToText(number % 1000000000);
            }
        }

        
    }
}
