using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller;
using Controller.Game;
using Controller.Menu;
using WpfController.Menu;
using WpfController.Game;

namespace WpfController
{
    public class WpfControllersManager : ControllersManager
    {

        public WpfControllersManager()
        {

        }

        protected override GameController GetGameController()
        {
            return WpfGameController.GetInstance();
        }

        protected override InfoController GetInfoController()
        {
            return WpfInfoController.GetInstance();
        }

        protected override MenuController GetMenuController()
        {
            return WpfMenuController.GetInstance();
        }

        protected override RecordsController GetRecordsController()
        {
            return WpfRecordsController.GetInstance();
        }

        protected override EndGameController GetEndGameController()
        {
            return WpfEndGameController.GetInstance();
        }
    }
}
