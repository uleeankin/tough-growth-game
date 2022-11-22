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

        public ConsoleInfoController() : base()
        {
            Info = new Info();
            //_viewInfo = new ConsoleView.Menu.ConsoleViewInfo(Info);
        } 

        public override void Start()
        {
            while(true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Enter:
                        Info.SelectFocusedItem();
                        break;
                }


            }
        }

        public override void Stop()
        {
            
        }
    }
}
