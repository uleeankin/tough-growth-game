using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Model.Utils
{
    public class FileIO
    {

        public static void FileWriter(string parFileName, string parText)
        {

        }

        public static List<string> FileReader(string parFileName)
        {
            List<string> fileContent = new List<string>();
            if (File.Exists(parFileName))
            {
                fileContent = File.ReadAllLines(parFileName).ToList();

            } else
            {
                File.Create(parFileName).Close();
            }
            return fileContent;
        }
    }
}
