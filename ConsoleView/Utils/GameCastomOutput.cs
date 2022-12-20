using Model.Enums;
using Model.Game.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleView.Utils
{
    public class GameCastomOutput
    {
        private const ConsoleColor INACTIVE_COLOR = ConsoleColor.Black;
        private const ConsoleColor FOOD_COLOR = ConsoleColor.Yellow;
        private const ConsoleColor HEXAGON_COLOR = ConsoleColor.Green;
        private const ConsoleColor CIRCLE_COLOR = ConsoleColor.Blue;
        private const ConsoleColor TRIANGLE_COLOR = ConsoleColor.Red;
        private const ConsoleColor RECTANGLE_COLOR = ConsoleColor.DarkMagenta;
        private const ConsoleColor SQUARE_COLOR = ConsoleColor.DarkRed;
        private const ConsoleColor GAME_SQUARE_COLOR = ConsoleColor.Magenta;

        private string[] _square = { "*****", "*****", "*****" };
        private string[] _hexagon = { "  ***", " *****", "*******", " *****", "  ***" };
        private string[] _circle = { " *****", "*******", "*******", " ***** " };
        private string[] _triangle = { "*", "***", "*****", "***", "*" };

        private static GameCastomOutput _instance = null;
        
        private GameCastomOutput()
        {
            
        }

        public static GameCastomOutput GetInstance()
        {
            if (_instance == null)
            {
                _instance = new GameCastomOutput();
            }
            return _instance;
        }

        public void CreateGameObjectView(GameObject parGameObject, int parX, int parY)
        {

            switch (parGameObject.ID)
            {
                case GameObjectTypes.GAME_SQUARE:
                    PrintActiveSquare(parX, parY, ConsoleColor.Magenta);
                    break;
                case GameObjectTypes.PERMANENT_SQUARE:
                    PrintActiveSquare(parX, parY, ConsoleColor.Yellow);
                    break;
                case GameObjectTypes.SQUARE:
                    PrintSquare(parX, parY, ConsoleColor.White);
                        //GetColorByState(parGameObject.State, parGameObject.ID));
                    break;
                case GameObjectTypes.HEXAGON:
                    PrintHexagon(parX, parY,
                        GetColorByState(parGameObject.State, parGameObject.ID));
                    break;
                case GameObjectTypes.CIRCLE:
                    PrintCircle(parX, parY,
                        GetColorByState(parGameObject.State, parGameObject.ID));
                    break;
                case GameObjectTypes.TRIANGLE:
                    PrintTriangle(parX, parY,
                        GetColorByState(parGameObject.State, parGameObject.ID));
                    break;
                case GameObjectTypes.RECTANGLE:
                    if (((Rectangle)parGameObject).Orientation == 1)
                    {
                        PrintHorizantalRectangle(parX, parY,
                            GetColorByState(parGameObject.State, parGameObject.ID));
                    }
                    else
                    {
                        PrintVerticalRectangle(parX, parY,
                            GetColorByState(parGameObject.State, parGameObject.ID));
                    }
                    break;
            }
        }

        private void PrintVerticalRectangle(int parX, int parY, ConsoleColor parColor)
        {
            Console.ForegroundColor = parColor;
            Console.SetCursorPosition(parX, parY);
            Console.Write("***");
            Console.SetCursorPosition(parX, parY + 1);
            Console.Write("***");
            Console.SetCursorPosition(parX, parY + 2);
            Console.Write("***");
            Console.SetCursorPosition(parX, parY + 3);
            Console.Write("***");
            Console.SetCursorPosition(parX, parY + 4);
            Console.Write("***");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void PrintHorizantalRectangle(int parX, int parY, ConsoleColor parColor)
        {
            Console.ForegroundColor = parColor;
            Console.SetCursorPosition(parX, parY);
            Console.Write("***********");
            Console.SetCursorPosition(parX, parY + 1);
            Console.Write("***********");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void PrintActiveSquare(int parX, int parY, ConsoleColor parColor)
        {
            Console.SetCursorPosition(parX, parY);
            Console.BackgroundColor = parColor;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
        }

        private void PrintSquare(int parX, int parY, ConsoleColor parColor)
        {
            Console.ForegroundColor = parColor;
            Console.SetCursorPosition(parX, parY);
            foreach (string elLine in _square)
            {
                Console.Write(elLine);
                Console.SetCursorPosition(parX, parY + 1);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void PrintHexagon(int parX, int parY, ConsoleColor parColor)
        {
            Console.ForegroundColor = parColor;
            Console.SetCursorPosition(parX, parY);
            foreach (string elLine in _hexagon)
            {
                Console.Write(elLine);
                Console.SetCursorPosition(parX, parY + 1);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void PrintCircle(int parX, int parY, ConsoleColor parColor)
        {
            Console.ForegroundColor = parColor;
            Console.SetCursorPosition(parX, parY);
            foreach (string elLine in _circle)
            {
                Console.Write(elLine);
                Console.SetCursorPosition(parX, parY + 1);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void PrintTriangle(int parX, int parY, ConsoleColor parColor)
        {
            Console.ForegroundColor = parColor;
            Console.SetCursorPosition(parX, parY);
            foreach (string elLine in _triangle)
            {
                Console.Write(elLine);
                Console.SetCursorPosition(parX, parY + 1);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void RedrawObject(GameObject parGameObject,
            int parOldXCoordinate, int parOldYCoordinate,
            int parNewXCoordinate, int parNewYCoordinate)
        {
            switch (parGameObject.ID)
            {
                case GameObjectTypes.GAME_SQUARE:
                    if (parNewXCoordinate > 0 && parNewYCoordinate > 0
                    && parNewXCoordinate < 120 && parNewYCoordinate < 30)
                    {
                        ClearActiveSquare(parOldXCoordinate, parOldYCoordinate);
                        PrintActiveSquare(parNewXCoordinate, parNewYCoordinate,
                            GetColorByState(parGameObject.State, parGameObject.ID));
                    }
                    break;
                case GameObjectTypes.PERMANENT_SQUARE:
                    ClearActiveSquare(parOldXCoordinate, parOldYCoordinate);
                    PrintActiveSquare(parNewXCoordinate, parNewYCoordinate,
                        GetColorByState(parGameObject.State, parGameObject.ID));
                    break;
                case GameObjectTypes.SQUARE:
                    PrintSquare(parOldXCoordinate, parOldYCoordinate,
                        GetColorByState(parGameObject.State, parGameObject.ID));
                    break;
                case GameObjectTypes.HEXAGON:
                    PrintHexagon(parOldXCoordinate, parOldYCoordinate,
                        GetColorByState(parGameObject.State, parGameObject.ID));
                    break;
                case GameObjectTypes.CIRCLE:
                    PrintCircle(parOldXCoordinate, parOldYCoordinate,
                        GetColorByState(parGameObject.State, parGameObject.ID));
                    break;
                case GameObjectTypes.TRIANGLE:
                    PrintTriangle(parOldXCoordinate, parOldYCoordinate,
                        GetColorByState(parGameObject.State, parGameObject.ID));
                    break;
                case GameObjectTypes.RECTANGLE:
                    if (((Rectangle)parGameObject).Orientation == 1)
                    {
                        PrintHorizantalRectangle(parOldXCoordinate, parOldYCoordinate,
                            GetColorByState(parGameObject.State, parGameObject.ID));
                    }
                    else
                    {
                        PrintVerticalRectangle(parOldXCoordinate, parOldYCoordinate,
                            GetColorByState(parGameObject.State, parGameObject.ID));
                    }
                    break;
            }
        }

        private void ClearActiveSquare(int parX, int parY)
        {
            Console.SetCursorPosition(parX, parY);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("  ");
        }

        private ConsoleColor GetColorByState(GameObjectsStates parState, GameObjectTypes parType)
        {
            if (parState == GameObjectsStates.FOOD)
            {
                return FOOD_COLOR;
            }


            if (parState == GameObjectsStates.INACTIVE
                || parState == GameObjectsStates.EATEN)
            {
                //return INACTIVE_COLOR;
                return ConsoleColor.White;
            }

            if (parState == GameObjectsStates.BARRIER)
            {
                switch (parType)
                {
                    case GameObjectTypes.SQUARE:
                        return SQUARE_COLOR;
                    case GameObjectTypes.CIRCLE:
                        return CIRCLE_COLOR;
                    case GameObjectTypes.RECTANGLE:
                        return RECTANGLE_COLOR;
                    case GameObjectTypes.TRIANGLE:
                        return TRIANGLE_COLOR;
                    case GameObjectTypes.HEXAGON:
                        return HEXAGON_COLOR;
                }
            }


            if (parState == GameObjectsStates.NO_STATE
                && parType == GameObjectTypes.GAME_SQUARE)
            {
                return GAME_SQUARE_COLOR;
            }

            return INACTIVE_COLOR;
        }
    }
}
