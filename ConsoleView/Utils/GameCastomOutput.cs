using Model.Enums;
using Model.Game.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Barrier = Model.Game.GameObjects.Barrier;

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

        private static GameCastomOutput _instance = null;

        private Object _lock = null;
        
        private GameCastomOutput()
        {
            _lock = new Object();    
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
                    PrintActiveSquare(parX, parY,
                        GetColorByState(parGameObject.State, parGameObject.ID));
                    break;
                case GameObjectTypes.PERMANENT_SQUARE:
                    PrintActiveSquare(parX, parY,
                        GetColorByState(parGameObject.State, parGameObject.ID));
                    break;
                case GameObjectTypes.SQUARE:
                    PrintSquare(parX, parY, 
                        GetColorByState(parGameObject.State, parGameObject.ID));
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
            lock(_lock)
            {
                Console.ForegroundColor = parColor;
                Console.SetCursorPosition(parX, parY);
                Console.Write("▯");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private void PrintHorizantalRectangle(int parX, int parY, ConsoleColor parColor)
        {
            lock(_lock)
            {
                Console.ForegroundColor = parColor;
                Console.SetCursorPosition(parX, parY);
                Console.Write("▭");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private void PrintActiveSquare(int parX, int parY, ConsoleColor parColor)
        {
            lock(_lock)
            {
                Console.ForegroundColor = parColor;
                Console.SetCursorPosition(parX, parY);
                Console.Write("□");
                Console.ForegroundColor = ConsoleColor.Black;
            }
        }

        private void PrintSquare(int parX, int parY, ConsoleColor parColor)
        {
            lock(_lock)
            {
                Console.ForegroundColor = parColor;
                Console.SetCursorPosition(parX, parY);
                Console.Write("□");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private void PrintHexagon(int parX, int parY, ConsoleColor parColor)
        {
            lock(_lock)
            {
                Console.ForegroundColor = parColor;
                Console.SetCursorPosition(parX, parY);
                Console.Write("#");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private void PrintCircle(int parX, int parY, ConsoleColor parColor)
        {
            lock(_lock)
            {
                Console.ForegroundColor = parColor;
                Console.SetCursorPosition(parX, parY);
                Console.Write("o");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private void PrintTriangle(int parX, int parY, ConsoleColor parColor)
        {
            lock(_lock)
            {
                Console.ForegroundColor = parColor;
                Console.SetCursorPosition(parX, parY);
                Console.Write("▷");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void RedrawObject(GameObject parGameObject,
            int parOldXCoordinate, int parOldYCoordinate,
            int parNewXCoordinate, int parNewYCoordinate)
        {
            switch (parGameObject.ID)
            {
                case GameObjectTypes.GAME_SQUARE:
                    Clear(parOldXCoordinate, parOldYCoordinate);
                    PrintActiveSquare(parNewXCoordinate, parNewYCoordinate,
                        GetColorByState(parGameObject.State, parGameObject.ID));
                    break;
                case GameObjectTypes.PERMANENT_SQUARE:
                    Clear(parOldXCoordinate, parOldYCoordinate);
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

        public void Clear(int parX, int parY)
        {
            lock (_lock)
            {
                Console.SetCursorPosition(parX, parY);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(" ");
            }
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
                return INACTIVE_COLOR;
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

        public void CreateBarrierView(Barrier parBarrier, int parX, int parY)
        {
            lock (_lock)
            {
                Console.ForegroundColor = GetColorByState(
                    GameObjectsStates.BARRIER, parBarrier.Parent.ID);
                Console.SetCursorPosition(parX, parY);
                Console.Write("◦");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void RedrawBarrier(Barrier parBarrier,
            int parOldXCoordinate, int parOldYCoordinate,
            int parNewXCoordinate, int parNewYCoordinate)
        {
            lock (_lock)
            {
                Console.ForegroundColor = GetColorByState(
                    GameObjectsStates.BARRIER, parBarrier.Parent.ID);
                Console.SetCursorPosition(parNewXCoordinate, parNewYCoordinate);
                Console.Write("*");
                if (parOldXCoordinate == ConsoleCoordinatesConverter.ConvertX(parBarrier.Parent.X)
                    && parOldYCoordinate == ConsoleCoordinatesConverter.ConvertY(parBarrier.Parent.Y))
                {
                    CreateGameObjectView(parBarrier.Parent, parOldXCoordinate, parOldYCoordinate);
                }
                else
                {
                    Clear(parOldXCoordinate, parOldYCoordinate);
                }

                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
