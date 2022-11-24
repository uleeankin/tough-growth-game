using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleView.Utils
{
    public class CastomOutput
    {

        private const int BUTTON_HEIGHT = 3;
        private const int BUTTON_WIDTH = 17;

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

        protected static Dictionary<Model.Enums.States, ConsoleColor> BackgroundColorByState { get; private set; }
        protected static Dictionary<Model.Enums.States, ConsoleColor> FontColorByState { get; private set; }

        public CastomOutput()
        {
            BackgroundColorByState = new Dictionary<Model.Enums.States, ConsoleColor>();
            BackgroundColorByState[Model.Enums.States.Focused] = ConsoleColor.White;
            BackgroundColorByState[Model.Enums.States.Normal] = ConsoleColor.Black;
            BackgroundColorByState[Model.Enums.States.Selected] = ConsoleColor.Black;

            FontColorByState = new Dictionary<Model.Enums.States, ConsoleColor>();
            FontColorByState[Model.Enums.States.Focused] = ConsoleColor.Black;
            FontColorByState[Model.Enums.States.Normal] = ConsoleColor.White;
            FontColorByState[Model.Enums.States.Selected] = ConsoleColor.Black;
        }

        public void OutputButton(string parText,
            int parCursorXPosition, 
            int parCursorYPosition,
            Model.Enums.States parState)
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

        private string[] GetBorder(Model.Enums.States parState)
        {
            List<string> buttonBorders = new List<string>();

            if (parState == Model.Enums.States.Normal)
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

        private int GetOffset(int parConsoleWidth)
        {
            int length = _titleCoordinates.Max(x => x.Max());

            return parConsoleWidth / 2 - length / 2;
        }

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
