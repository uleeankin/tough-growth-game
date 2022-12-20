using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleView.Utils
{
    public class ConsoleCoordinatesConverter
    {

        public ConsoleCoordinatesConverter()
        {

        }

        public static int ConvertX(double parX)
        {
            return (int)Math.Floor(parX / 8.3);
        }

        public static int ConvertY(double parY)
        {
            return (int)Math.Floor(parY / 18);
        }
    }
}
