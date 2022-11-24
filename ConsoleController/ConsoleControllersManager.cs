using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller;
using ConsoleController.Menu;
using Controller.Menu;
using Model.Enums;

namespace ConsoleController
{
    public class ConsoleControllersManager : ControllersManager
    {
        public ConsoleControllersManager()
        {

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
