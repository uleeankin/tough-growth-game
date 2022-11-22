using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller.Menu;
using View.Menu;

namespace ConsoleController.Menu
{
    public class ConsoleRecordsController : RecordsController
    {

        private static ConsoleRecordsController _instance;

        private ViewRecords _viewRecords = null;

        private ConsoleControllersManager _controllersManager = null;

        private ConsoleRecordsController(ConsoleControllersManager parManager) : base()
        {
            Records = new Model.Menu.Records();
            _viewRecords = new ConsoleView.Menu.ConsoleViewRecords(Records);
            _controllersManager = parManager;
        }

        public static ConsoleRecordsController GetInstance(ConsoleControllersManager parManager)
        {
            if (_instance == null)
            {
                _instance = new ConsoleRecordsController(parManager);
            }
            return _instance;
        }

        public override void Start()
        {
            
        }

        public override void Stop()
        {
            
        }
    }
}
