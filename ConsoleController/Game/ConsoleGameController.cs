using ConsoleView.Game;
using Controller.Game;
using Model.Enums;
using Model.Game.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Game;

namespace ConsoleController.Game
{
    /// <summary>
    /// Контроллер окна игры (консоль)
    /// </summary>
    public class ConsoleGameController : GameController
    {
        /// <summary>
        /// Сущность контроллера игры
        /// </summary>
        private static ConsoleGameController _instance;

        /// <summary>
        /// Представление окна игры
        /// </summary>
        private ViewGame _viewGame = null;

        /// <summary>
        /// Флаг состояния контроллера игры
        /// </summary>
        protected bool IsExit { get; set; }

        /// <summary>
        /// Конструктор контроллера игры
        /// </summary>
        private ConsoleGameController() : base()
        {
            Game = new Model.Game.GameScreen();
            Game.ScreenHeight = 550;
            Game.ScreenWidth = 1000;
            _viewGame = new ConsoleViewGame(Game);
        }

        /// <summary>
        /// Получает или создает сущность контроллера игры
        /// </summary>
        /// <returns>Контроллер игры</returns>
        public static ConsoleGameController GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ConsoleGameController();
            }
            return _instance;
        }

        /// <summary>
        /// Запускает работу контроллера игры
        /// </summary>
        public override void Start()
        {
            IsExit = false;
            Game.EndGame += EndGame;
            _viewGame.Draw();
            Game.StartGame();
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        Game.MoveUp((GameSquare)Game.GameObjects[(int)GameObjectTypes.GAME_SQUARE]);
                        break;
                    case ConsoleKey.DownArrow:
                        Game.MoveDown((GameSquare)Game.GameObjects[(int)GameObjectTypes.GAME_SQUARE]);
                        break;
                    case ConsoleKey.LeftArrow:
                        Game.MoveLeft((GameSquare)Game.GameObjects[(int)GameObjectTypes.GAME_SQUARE]);
                        break;
                    case ConsoleKey.RightArrow:
                        Game.MoveRight((GameSquare)Game.GameObjects[(int)GameObjectTypes.GAME_SQUARE]);
                        break;
                    case ConsoleKey.Escape:
                        SwitchController(ControlItemCode.MainMenu);
                        break;
                }
            } while (!IsExit);
        }

        /// <summary>
        /// Останавливает работу контроллера игры
        /// </summary>
        public override void Stop()
        {
            Game.StopGame();
            IsExit = true;
        }

        /// <summary>
        /// Завершает процесс игры
        /// </summary>
        private void EndGame()
        {
            Game.StopGame();
            SwitchController(ControlItemCode.EndGame);
        }
    }
}
