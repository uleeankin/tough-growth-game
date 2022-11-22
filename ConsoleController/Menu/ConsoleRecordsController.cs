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
        private ViewRecords _viewRecords = null;

        private ConsoleControllersManager _controllersManager = null;

        public ConsoleRecordsController(ConsoleControllersManager parManager) : base()
        {
            Records = new Model.Menu.Records();
            _viewRecords = new ConsoleView.Menu.ConsoleViewRecords(Records);
            _controllersManager = parManager;
        }

        public override void Start()
        {
            
        }

        public override void Stop()
        {
            
        }
    }
}
