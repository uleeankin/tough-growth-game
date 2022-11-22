using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToughGrowth
{
    public class Program
    {
        static void Main(string[] args)
        {
            ConsoleController.ConsoleControllersManager manager = new ConsoleController.ConsoleControllersManager();
            manager.Start();
        }
    }
}
