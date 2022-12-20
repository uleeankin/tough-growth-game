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
    public class ConsoleGameController : GameController
    {

        private static ConsoleGameController _instance;

        private ViewGame _viewGame = null;
        protected bool IsExit { get; set; }

        private ConsoleGameController() : base()
        {
            Game = new Model.Game.GameScreen();
            Game.ScreenHeight = 550;
            Game.ScreenWidth = 1000;
            _viewGame = new ConsoleViewGame(Game);
        }

        public static ConsoleGameController GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ConsoleGameController();
            }
            return _instance;
        }

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

        public override void Stop()
        {
            Game.StopGame();
            IsExit = true;
        }

        private void EndGame()
        {
            Game.StopGame();
            SwitchController(ControlItemCode.EndGame);
        }
    }
}
