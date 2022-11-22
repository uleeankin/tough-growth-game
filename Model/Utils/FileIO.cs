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
            try
            {
                using (StreamReader reader = new StreamReader(parFileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        fileContent.Add(line);
                    }
                }
                    
            }
            catch(FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            
            return fileContent;
        }
    }
}
