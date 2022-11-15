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
    }
}
