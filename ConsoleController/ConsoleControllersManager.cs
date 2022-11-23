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

        public override void Start()
        {
            Menu = ConsoleMenuController.GetInstance(this);
            CurrentController = Menu;
            CurrentController.Start();
        }

        public override void GetMove(ControlItemCode parCode)
        {
            CurrentController.Stop();
            switch (parCode)
            {
                case ControlItemCode.Records:
                    Records = ConsoleRecordsController.GetInstance(this);
                    CurrentController = Records;
                    Records.Start();
                    break;
                case ControlItemCode.Info:
                    Info = ConsoleInfoController.GetInstance(this);
                    CurrentController = Info;
                    Info.Start();
                    break;
                case ControlItemCode.MainMenu:
                    Menu = ConsoleMenuController.GetInstance(this);
                    CurrentController = Menu;
                    Menu.Start();
                    break;
            }
        }


    }
}
