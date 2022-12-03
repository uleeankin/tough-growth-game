using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller;
using Controller.Menu;
using WpfController.Menu;

namespace WpfController
{
    public class WpfControllersManager : ControllersManager
    {

        public WpfControllersManager()
        {

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
    }
}
