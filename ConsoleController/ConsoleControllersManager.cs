using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller;
using ConsoleController.Menu;
using Controller.Menu;
using Model.Enums;
using Controller.Game;
using ConsoleController.Game;

namespace ConsoleController
{
    public class ConsoleControllersManager : ControllersManager
    {
        public ConsoleControllersManager()
        {

        }

        protected override EndGameController GetEndGameController()
        {
            return ConsoleEndGameController.GetInstance();
        }

        protected override GameController GetGameController()
        {
            return ConsoleGameController.GetInstance();
        }

        protected override InfoController GetInfoController()
        {
            return ConsoleInfoController.GetInstance();
        }

        protected override MenuController GetMenuController()
        {
            return ConsoleMenuController.GetInstance();
        }

        protected override RecordsController GetRecordsController()
        {
            return ConsoleRecordsController.GetInstance();
        }
    }
}
