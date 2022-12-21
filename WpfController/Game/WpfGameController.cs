using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller.Game;
using System.Windows.Input;
using View.Game;
using WpfView;
using Model.Game;
using Model.Enums;
using Model.Game.GameObjects;
using System.Threading;
using System.Windows;

namespace WpfController.Game
{
    /// <summary>
    /// Контроллер игры (wpf)
    /// </summary>
    public class WpfGameController : GameController
    {

        /// <summary>
        /// Сущность контроллера игры
        /// </summary>
        private static WpfGameController _instance;

        /// <summary>
        /// Общее wpf окно для всех окон
        /// </summary>
        private MainScreen _screen = null;

        /// <summary>
        /// Представление игры
        /// </summary>
        private ViewGame _viewGame = null;

        /// <summary>
        /// Конструктор контроллера игры
        /// </summary>
        private WpfGameController() : base()
        {
            _screen = MainScreen.GetInstance();
            Game = new GameScreen();
            Game.ScreenHeight = _screen.Height;
            Game.ScreenWidth = _screen.Width;
            _viewGame = new WpfView.Game.WpfViewGame(Game);
        }

        /// <summary>
        /// Получает сущность контроллера игры
        /// </summary>
        /// <returns></returns>
        public static WpfGameController GetInstance()
        {
            if (_instance == null)
            {
                _instance = new WpfGameController();
            }
            return _instance;
        }

        /// <summary>
        /// Обработчик события нажатия на клавиши клавиатуры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up:
                    Game.MoveUp((GameSquare)Game.GameObjects[(int)GameObjectTypes.GAME_SQUARE]);
                    break;
                case Key.Down:
                    Game.MoveDown((GameSquare)Game.GameObjects[(int)GameObjectTypes.GAME_SQUARE]);
                    break;
                case Key.Left:
                    Game.MoveLeft((GameSquare)Game.GameObjects[(int)GameObjectTypes.GAME_SQUARE]);
                    break;
                case Key.Right:
                    Game.MoveRight((GameSquare)Game.GameObjects[(int)GameObjectTypes.GAME_SQUARE]);
                    break;
                case Key.Escape:
                    SwitchController(ControlItemCode.MainMenu);
                    break;
            }
        }

        /// <summary>
        /// Запускает работу MVC игры
        /// </summary>
        public override void Start()
        {
            _screen.KeyDown += OnKeyDownHandler;
            Game.EndGame += EndGame;
            _viewGame.Draw();
            Game.StartGame();
        }

        /// <summary>
        /// Останавливает работу MVC игры
        /// </summary>
        public override void Stop()
        {
            _screen.KeyDown -= OnKeyDownHandler;
            Game.StopGame();
        }

        /// <summary>
        /// Останавливает игровой цикл и  переключает контроллер
        /// </summary>
        private void EndGame()
        {
            Game.StopGame();
            SwitchController(ControlItemCode.EndGame);
        }
    }
}
