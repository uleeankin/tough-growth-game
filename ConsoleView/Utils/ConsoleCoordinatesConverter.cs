using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleView.Utils
{
    /// <summary>
    /// Класс для преобразования вещественных координат в координаты консоли
    /// </summary>
    public class ConsoleCoordinatesConverter
    {

        /// <summary>
        /// Конструктор прпеобразователя
        /// </summary>
        public ConsoleCoordinatesConverter()
        {

        }

        /// <summary>
        /// Преобразует координату X
        /// </summary>
        /// <param name="parX"></param>
        /// <returns></returns>
        public static int ConvertX(double parX)
        {
            return (int)Math.Floor(parX / 33);
        }

        /// <summary>
        /// Преобразует координату Y
        /// </summary>
        /// <param name="parY"></param>
        /// <returns></returns>
        public static int ConvertY(double parY)
        {
            return (int)Math.Floor(parY / 36) + 1;
        }
    }
}
