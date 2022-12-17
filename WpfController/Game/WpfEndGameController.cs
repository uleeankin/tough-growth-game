using Controller.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        }

        public static WpfEndGameController GetInstance()
        {
            if (_instance == null)
            {
                _instance = new WpfEndGameController();
            }
            return _instance;
        }

        public override void Start()
        {
            
        }

        public override void Stop()
        {
            
        }
    }
}
