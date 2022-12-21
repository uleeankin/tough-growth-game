using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Model.Utils
{
    /// <summary>
    /// Класс для считывания / записи данных в файл
    /// </summary>
    public class FileIO
    {

        /// <summary>
        /// Записывает текст в файл
        /// </summary>
        /// <param name="parFileName">Имя файла</param>
        /// <param name="parText">Текст</param>
        public static void FileWriter(string parFileName, string parText)
        {
            File.AppendAllText(parFileName, parText);
        }

        /// <summary>
        /// Получает рекорды из файла
        /// </summary>
        /// <param name="parFileName">Имя файла</param>
        /// <returns>Возвращает список пар: имя игрока - количество смертей</returns>
        public static List<Tuple<string, int>> RecordsFileReader(string parFileName)
        {
            List<Tuple<string, int>> fileContent = new List<Tuple<string, int>>();

            if (File.Exists(parFileName))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(parFileName))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] records = line.Split(' ');
                            fileContent.Add(new Tuple<string, int>(records[0], int.Parse(records[1])));
                        }
                    }

                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            
            return fileContent;
        }
    }
}
