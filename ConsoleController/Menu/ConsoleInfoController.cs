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
        //private ConsoleControllersManager _controllersManager = null;

        private ConsoleInfoController() : base()
        {
            
        }
        
        public static ConsoleInfoController GetInstance(ConsoleControllersManager parManager)
        {
            if (_instance == null)
            {
                _instance = new ConsoleInfoController();
                //_instance._controllersManager = parManager;
            }
            _instance.Info = new Info();
            _instance._viewInfo = new ConsoleView.Menu.ConsoleViewInfo(_instance.Info);
            foreach (Model.Items.ControlItem elItem in _instance.Info.ControlItems)
            {
                elItem.Selected += () => { parManager.GetMove((ControlItemCode)elItem.ID); };
            }
            return _instance;
        }

        public override void Start()
        {
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
