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

namespace WpfController.Game
{
    public class WpfGameController : GameController
    {

        private static WpfGameController _instance;

        private MainScreen _screen = null;
        private ViewGame _viewGame = null;

        private WpfGameController() : base()
        {
            _screen = MainScreen.GetInstance();
            Game = new GameScreen();
            Game.ScreenHeight = _screen.Height;
            Game.ScreenWidth = _screen.Width;
            _viewGame = new WpfView.Game.WpfViewGame(Game);
        }

        public static WpfGameController GetInstance()
        {
            if (_instance == null)
            {
                _instance = new WpfGameController();
            }
            return _instance;
        }

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

        public override void Start()
        {
            _screen.KeyDown += OnKeyDownHandler;
            _viewGame.Draw();
            ((GameSquare)Game.GameObjects[(int)GameObjectTypes.GAME_SQUARE])
                .StartMotion(10, (int)Game.ScreenHeight, (int)Game.ScreenWidth);
        }

        public override void Stop()
        {
            _screen.KeyDown -= OnKeyDownHandler;
            ((GameSquare)Game.GameObjects[(int)GameObjectTypes.GAME_SQUARE]).StopMotion();
        }
    }
}
