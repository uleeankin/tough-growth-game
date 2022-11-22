using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller.Menu;
using Model.Enums;

namespace Controller
{
    public class ControllersManager
    {
        protected Controller CurrentController { get; set; }
        protected MenuController Menu { get; set; }
        protected InfoController Info { get; set; }
        protected RecordsController Records { get; set; }

        public ControllersManager()
        {
            
        }

        public void GetMove(ControlItemCode parCode)
        {
            CurrentController.Stop();
            switch(parCode)
            {
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
            }
        }

    }
}
