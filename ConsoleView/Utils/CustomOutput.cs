using Model.Enums;
using Model.Game.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleView.Utils
{
    /// <summary>
    /// Выводитель
    /// </summary>
    public class CustomOutput
    {
        /// <summary>
        /// Высота кнопки
        /// </summary>
        private const int BUTTON_HEIGHT = 3;

        /// <summary>
        /// Ширина кнопки
        /// </summary>
        private const int BUTTON_WIDTH = 17;

        /// <summary>
        /// Координаты отрисовки заголовка игры
        /// </summary>
        private List<List<int>> _titleCoordinates = new List<List<int>>()
        {
            new List<int>() {1, 2, 3, 4, 5, 8, 9, 12, 15, 18, 19, 22, 25, 
                33, 34, 37, 38, 39, 43, 44, 47, 51, 53, 54, 55, 56, 57, 59, 62},
            new List<int>() {3, 7, 10, 12, 15, 17, 22, 25, 32, 37, 40,
                42, 45, 47, 51, 55, 59, 62},
            new List<int>() {3, 7, 10, 12, 15, 17, 19, 20, 22, 23, 24, 25, 
                32, 34, 35, 37, 38, 39, 42, 45, 47, 49, 51, 55, 59, 60, 61, 62},
            new List<int>() {3, 7, 10, 12, 15, 17, 20, 22, 25, 32, 35, 37, 
                39, 42, 45, 47, 49, 51, 55, 59, 62},
            new List<int>() {3, 8, 9, 12, 13, 14, 15, 18, 19, 22, 25, 33,
                34, 37, 40, 43, 44, 48, 50, 55, 59, 62}
        };

        /// <summary>
        /// Список цветов фонов объектов по состояниям
        /// </summary>
        protected static Dictionary<States, ConsoleColor> BackgroundColorByState { get; private set; }

        /// <summary>
        /// Список цветов объектов по состояниям
        /// </summary>
        protected static Dictionary<States, ConsoleColor> FontColorByState { get; private set; }

        /// <summary>
        /// Конструктор выводителя
        /// </summary>
        public CustomOutput()
        {
            BackgroundColorByState = new Dictionary<States, ConsoleColor>();
            BackgroundColorByState[States.Focused] = ConsoleColor.White;
            BackgroundColorByState[States.Normal] = ConsoleColor.Black;
            BackgroundColorByState[States.Selected] = ConsoleColor.Black;

            FontColorByState = new Dictionary<States, ConsoleColor>();
            FontColorByState[States.Focused] = ConsoleColor.Black;
            FontColorByState[States.Normal] = ConsoleColor.White;
            FontColorByState[States.Selected] = ConsoleColor.Black;
        }

        /// <summary>
        /// Выводит кнопку
        /// </summary>
        /// <param name="parText">Текст на кнопке</param>
        /// <param name="parCursorXPosition">Координата X кнопки</param>
        /// <param name="parCursorYPosition">Координата Y кнопки</param>
        /// <param name="parState">Состояние кнопки</param>
        public void OutputButton(string parText,
            int parCursorXPosition, 
            int parCursorYPosition,
            States parState)
        {
            string[] buttonBorder = GetBorder(parState);
            Console.BackgroundColor = BackgroundColorByState[parState];
            Console.ForegroundColor = FontColorByState[parState];

            int buttonCursorXPosition = parCursorXPosition - (BUTTON_WIDTH / 2 - parText.Length / 2);
            int buttonCursorYPosition = parCursorYPosition - 1;

            Console.CursorLeft = buttonCursorXPosition;
            Console.CursorTop = buttonCursorYPosition;

            for (int i = 0; i < BUTTON_HEIGHT; i++)
            {
                Console.Write(buttonBorder[i]);
                Console.CursorTop = ++buttonCursorYPosition;
                Console.CursorLeft = buttonCursorXPosition;
            }

            Console.SetCursorPosition(parCursorXPosition, parCursorYPosition);
            Console.Write(parText);
        }

        /// <summary>
        /// Получает границы кнопок
        /// </summary>
        /// <param name="parState">Состояние кнопки</param>
        /// <returns>Элементы границ кнопки</returns>
        private string[] GetBorder(States parState)
        {
            List<string> buttonBorders = new List<string>();

            if (parState == States.Normal)
            {
                buttonBorders.Add(new StringBuilder().Append("┌")
                                                    .Append('─', BUTTON_WIDTH - 2)
                                                    .Append("┐").ToString());
                buttonBorders.Add(new StringBuilder().Append("│")
                                                    .Append(' ', BUTTON_WIDTH - 2)
                                                    .Append("│").ToString());
                buttonBorders.Add(new StringBuilder().Append("└")
                                                    .Append('─', BUTTON_WIDTH - 2)
                                                    .Append("┘").ToString());

            } else
            {
                for (int i = 0; i < BUTTON_HEIGHT; i++)
                {
                    buttonBorders.Add(new StringBuilder().Append(' ', BUTTON_WIDTH).ToString());
                }
            }

            return buttonBorders.ToArray();
        }

        /// <summary>
        /// Выводит заголовок игры
        /// </summary>
        /// <param name="parConsoleWidth">Ширина окна консоли</param>
        public void PrintGameTitle(int parConsoleWidth)
        {
            int offset = GetOffset(parConsoleWidth);
            Console.SetCursorPosition(offset, 1);


            for (int i = 0; i < _titleCoordinates.Count; i++)
            {
                for (int j = 0; j < parConsoleWidth; j++)
                {
                    if (_titleCoordinates[i].Contains(Console.CursorLeft - offset))
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(" ");
                        Console.BackgroundColor = ConsoleColor.Black;
                    } else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" ");
                    }
                }
                Console.CursorLeft = offset;
            }
        }

        /// <summary>
        /// Вычисляет отступы между буквами заголовка
        /// </summary>
        /// <param name="parConsoleWidth">Ширина окна консоли</param>
        /// <returns></returns>
        private int GetOffset(int parConsoleWidth)
        {
            int length = _titleCoordinates.Max(x => x.Max());

            return parConsoleWidth / 2 - length / 2;
        }

        /// <summary>
        /// Выводит строку в консоль
        /// </summary>
        /// <param name="parString">Строка</param>
        /// <param name="parCursorXPosition">Координата X</param>
        /// <param name="parCursorYPosition">Координата Y</param>
        public void OutputString(
            string parString,
            int parCursorXPosition,
            int parCursorYPosition)
        {
            Console.SetCursorPosition(parCursorXPosition, parCursorYPosition);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(parString);
        }
    }
}
