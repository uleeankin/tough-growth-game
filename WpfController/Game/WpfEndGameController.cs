using Controller.Game;
using Model.Enums;
using Model.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using View.Game;
using WpfView;

namespace WpfController.Game
{
    public class WpfEndGameController : EndGameController
    {

        private static WpfEndGameController _instance;

        private ViewEndGame _viewEndGame = null;
        private MainScreen _screen = null;

        private WpfEndGameController() : base()
        {
            _screen = MainScreen.GetInstance();
            End = new Model.Game.EndGameScreen();
            _viewEndGame = new WpfView.Game.WpfViewEndGame(End);
            foreach (ControlItem elItem in End.ControlItems)
            {
                elItem.Selected += () => { SwitchController((ControlItemCode)elItem.ID); };
            }
        }

        public static WpfEndGameController GetInstance()
        {
            if (_instance == null)
            {
                _instance = new WpfEndGameController();
            }
            return _instance;
        }

        public void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter:
                    End.SelectFocusedItem();
                    break;
            }
        }

        public override void Start()
        {
            _screen.KeyDown += OnKeyDownHandler;
            _viewEndGame.Draw();
        }

        public override void Stop()
        {
            _screen.KeyDown -= OnKeyDownHandler;
        }
    }
}
