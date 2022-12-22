using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToughGrowth
{
    /// <summary>
    /// Класс запуска консольной версии приложения
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Точка входа в программу
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ConsoleController.ConsoleControllersManager manager = new ConsoleController.ConsoleControllersManager();
            manager.Start();
        }
    }
}
