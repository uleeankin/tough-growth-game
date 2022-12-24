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
    /// <summary>
    /// Выводитель игровых объектов
    /// </summary>
    public class GameCustomOutput
    {
        /// <summary>
        /// Цвет неактивных объектов
        /// </summary>
        private const ConsoleColor INACTIVE_COLOR = ConsoleColor.Black;

        /// <summary>
        /// Цвет объектов, доступных для съедения
        /// </summary>
        private const ConsoleColor FOOD_COLOR = ConsoleColor.Yellow;

        /// <summary>
        /// Цвет шестиугольника в состоянии препятствия
        /// </summary>
        private const ConsoleColor HEXAGON_COLOR = ConsoleColor.Green;

        /// <summary>
        /// Цвет круга в состоянии препятствия
        /// </summary>
        private const ConsoleColor CIRCLE_COLOR = ConsoleColor.Blue;

        /// <summary>
        /// Цвет треугольника в состоянии препятствия
        /// </summary>
        private const ConsoleColor TRIANGLE_COLOR = ConsoleColor.Red;

        /// <summary>
        /// Цвет прямоугольника в состоянии препятствия
        /// </summary>
        private const ConsoleColor RECTANGLE_COLOR = ConsoleColor.DarkMagenta;

        /// <summary>
        /// Цвет квадрата в состоянии препятствия
        /// </summary>
        private const ConsoleColor SQUARE_COLOR = ConsoleColor.DarkRed;

        /// <summary>
        /// Цвет игрового квадрата
        /// </summary>
        private const ConsoleColor GAME_SQUARE_COLOR = ConsoleColor.Magenta;

        /// <summary>
        /// Сущность выводителя игровых объектов
        /// </summary>
        private static GameCustomOutput _instance = null;

        /// <summary>
        /// Заглушка
        /// </summary>
        private Object _lock = null;
        
        /// <summary>
        /// Конструктор выводителя игровых объектов
        /// </summary>
        private GameCustomOutput()
        {
            _lock = new Object();    
        }

        /// <summary>
        /// Получает или создает сущность выводителя
        /// </summary>
        /// <returns>Выводитель игровых объектов</returns>
        public static GameCustomOutput GetInstance()
        {
            if (_instance == null)
            {
                _instance = new GameCustomOutput();
            }
            return _instance;
        }

        /// <summary>
        /// Рисует игровой объект
        /// </summary>
        /// <param name="parGameObject">Модель игрового объекта</param>
        /// <param name="parX">Координата X</param>
        /// <param name="parY">Координата Y</param>
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

        /// <summary>
        /// Рисует вертикальный прямоугольник
        /// </summary>
        /// <param name="parX">Координата X</param>
        /// <param name="parY">Координата Y</param>
        /// <param name="parColor">Цвет прямоугольника</param>
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

        /// <summary>
        /// Рисует горизонтальный прямоугольник
        /// </summary>
        /// <param name="parX">Координата X</param>
        /// <param name="parY">Координата Y</param>
        /// <param name="parColor">Цвет прямоугольника</param>
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

        /// <summary>
        /// Рисует игровой или постоянный съедобный квадрат
        /// </summary>
        /// <param name="parX">Координата X</param>
        /// <param name="parY">Координата Y</param>
        /// <param name="parColor">Цвет квадрата</param>
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

        /// <summary>
        /// Рисует квадрат
        /// </summary>
        /// <param name="parX">Координата X</param>
        /// <param name="parY">Координата Y</param>
        /// <param name="parColor">Цвет квадрата</param>
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

        /// <summary>
        /// Рисует шестиугольник
        /// </summary>
        /// <param name="parX">Координата X</param>
        /// <param name="parY">Координата Y</param>
        /// <param name="parColor">Цвет шестиугольника</param>
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

        /// <summary>
        /// Рисует круг
        /// </summary>
        /// <param name="parX">Координата X</param>
        /// <param name="parY">Координата Y</param>
        /// <param name="parColor">Цвет круга</param>
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

        /// <summary>
        /// Рисует треугольник
        /// </summary>
        /// <param name="parX">Координата X</param>
        /// <param name="parY">Координата Y</param>
        /// <param name="parColor">Цвет треугольника</param>
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

        /// <summary>
        /// Перерисовывает игровой объект
        /// </summary>
        /// <param name="parGameObject">Игровой объект</param>
        /// <param name="parOldXCoordinate">Старая координата X</param>
        /// <param name="parOldYCoordinate">Старая координата Y</param>
        /// <param name="parNewXCoordinate">Новая координата X</param>
        /// <param name="parNewYCoordinate">Новая координата Y</param>
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

        /// <summary>
        /// Очищает указанную область консоли при движении
        /// </summary>
        /// <param name="parX">Координата X</param>
        /// <param name="parY">Координата Y</param>
        public void Clear(int parX, int parY)
        {
            lock (_lock)
            {
                if (parX >= 0 && parY >= 0)
                {
                    Console.SetCursorPosition(parX, parY);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                }
            }
        }

        /// <summary>
        /// Получает цвет объекта по его типу и состоянию
        /// </summary>
        /// <param name="parState">Состояние игрового объекта</param>
        /// <param name="parType">Тип игрового объекта</param>
        /// <returns></returns>
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

        /// <summary>
        /// Рисует препятствие на поле
        /// </summary>
        /// <param name="parBarrier">Модель препятствия</param>
        /// <param name="parX">Координата X</param>
        /// <param name="parY">Координата Y</param>
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

        /// <summary>
        /// Перерисовывает препятствие
        /// </summary>
        /// <param name="parBarrier">Модель препятствия</param>
        /// <param name="parOldXCoordinate">Старая координата X</param>
        /// <param name="parOldYCoordinate">Старая координата Y</param>
        /// <param name="parNewXCoordinate">Новая координата X</param>
        /// <param name="parNewYCoordinate">Новая координата Y</param>
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
