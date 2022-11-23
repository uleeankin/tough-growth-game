using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller.Menu;
using View.Menu;
using Model.Enums;

namespace ConsoleController.Menu
{
    public class ConsoleRecordsController : RecordsController
    {

        private static ConsoleRecordsController _instance;

        protected bool IsExit { get; set; }

        private ViewRecords _viewRecords = null;

        //private ConsoleControllersManager _controllersManager = null;

        private ConsoleRecordsController() : base()
        {
            
        }

        public static ConsoleRecordsController GetInstance(ConsoleControllersManager parManager)
        {
            if (_instance == null)
            {
                _instance = new ConsoleRecordsController();
                //_instance._controllersManager = parManager;
            }
            _instance.Records = new Model.Menu.Records();
            _instance._viewRecords = new ConsoleView.Menu.ConsoleViewRecords(_instance.Records);
            foreach (Model.Items.ControlItem elItem in _instance.Records.ControlItems)
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
                        Records.SelectFocusedItem();
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
