using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller.Menu;
using View.Menu;
using Model.Menu;

namespace ConsoleController.Menu
{
    public class ConsoleInfoController : InfoController
    {

        private ViewInfo _viewInfo = null;
        private ConsoleControllersManager _controllersManager = null;

        public ConsoleInfoController(ConsoleControllersManager parManager) : base()
        {
            Info = new Info();
            _viewInfo = new ConsoleView.Menu.ConsoleViewInfo(Info);
            _controllersManager = parManager;
        } 

        public override void Start()
        {
            bool x = false;
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Enter:
                        x = true;
                        Info.SelectFocusedItem();
                        break;
                }
            } while (x);
            
        }

        public override void Stop()
        {
            
        }
    }
}
