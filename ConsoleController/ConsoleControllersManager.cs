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

        public void Start()
        {
            Menu = new ConsoleMenuController(this);
            CurrentController = Menu;
            CurrentController.Start();
        }

        new public void GetMove(ControlItemCode parCode)
        {
            CurrentController.Stop();
            switch (parCode)
            {
                case ControlItemCode.Records:
                    if (Records == null)
                    {
                        Records = new ConsoleRecordsController(this);
                    }
                    CurrentController = Records;
                    Records.Start();
                    break;
                case ControlItemCode.Info:
                    if (Info == null)
                    {
                        Info = new ConsoleInfoController(this);
                    }
                    CurrentController = Info;
                    Info.Start();
                    break;
                case ControlItemCode.MainMenu:
                    if (Menu == null)
                    {
                        Menu = new ConsoleMenuController(this);
                    }
                    CurrentController = Menu;
                    Menu.Start();
                    break;
            }
        }


    }
}
