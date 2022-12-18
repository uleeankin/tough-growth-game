using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller.Menu;
using Controller.Game;
using Model.Enums;

namespace Controller
{
    public abstract class ControllersManager
    {
        protected Controller CurrentController { get; set; }
        protected MenuController Menu { get; set; }
        protected InfoController Info { get; set; }
        protected RecordsController Records { get; set; }
        protected GameController Game { get; set; }
        protected EndGameController EndGame { get; set; }

        public ControllersManager()
        {

        }

        public void GetMove(ControlItemCode parCode)
        {
            CurrentController.Stop();
            switch (parCode)
            {
                case ControlItemCode.Game:
                    CurrentController = Game;
                    Game.Start();
                    break;
                case ControlItemCode.Records:
                    CurrentController = Records;
                    Records.Start();
                    break;
                case ControlItemCode.Info:
                    CurrentController = Info;
                    Info.Start();
                    break;
                case ControlItemCode.MainMenu:
                    CurrentController = Menu;
                    Menu.Start();
                    break;
                case ControlItemCode.EndGame:
                    CurrentController = EndGame;
                    EndGame.End.Score = Game.Game.Deaths;
                    EndGame.Start();
                    break;
            }
        }

        public void Start()
        {
            InitControllers();
            SubscribeToEvents();
            CurrentController = Menu;
            CurrentController.Start();
        }

        private void SubscribeToEvents()
        {
            Menu.ChangeController += GetMove;
            Records.ChangeController += GetMove;
            Info.ChangeController += GetMove;
            Game.ChangeController += GetMove;
            EndGame.ChangeController += GetMove;
        }

        private void InitControllers()
        {
            Menu = this.GetMenuController();
            Records = this.GetRecordsController();
            Info = this.GetInfoController();
            Game = this.GetGameController();
            EndGame = this.GetEndGameController();
        }

        protected abstract MenuController GetMenuController();

        protected abstract InfoController GetInfoController();

        protected abstract RecordsController GetRecordsController();

        protected abstract GameController GetGameController();

        protected abstract EndGameController GetEndGameController();
    }
}
