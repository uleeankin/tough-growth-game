using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller.Menu;
using View.Menu;
using Model.Menu;
using Model.Enums;

namespace ConsoleController.Menu
{
    public class ConsoleInfoController : InfoController
    {

        private static ConsoleInfoController _instance;
        protected bool IsExit { get; set; }

        private ViewInfo _viewInfo = null;
        private ConsoleControllersManager _controllersManager = null;

        private ConsoleInfoController(ConsoleControllersManager parManager) : base()
        {
            Info = new Info();
            _viewInfo = new ConsoleView.Menu.ConsoleViewInfo(Info);
            _controllersManager = parManager;
            foreach (Model.Items.ControlItem elItem in Info.ControlItems)
            {
                elItem.Selected += () => { _controllersManager.GetMove((ControlItemCode)elItem.ID); };
            }
        }
        
        public static ConsoleInfoController GetInstance(ConsoleControllersManager parManager)
        {
            if (_instance == null)
            {
                _instance = new ConsoleInfoController(parManager);
            }
            return _instance;
        }

        public override void Start()
        {
            _viewInfo.Draw();
            IsExit = false;
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Enter:
                        Info.SelectFocusedItem();
                        break;
                }
            } while (!IsExit);
            
        }

        public override void Stop()
        {
            IsExit = !IsExit;
        }
    }
}
