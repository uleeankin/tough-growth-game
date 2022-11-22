using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller.Menu;
using Model.Enums;

namespace Controller
{
    public abstract class ControllersManager
    {
        protected Controller CurrentController { get; set; }
        protected MenuController Menu { get; set; }
        protected InfoController Info { get; set; }
        protected RecordsController Records { get; set; }

        public ControllersManager()
        {
            
        }

        public abstract void GetMove(ControlItemCode parCode);

        public abstract void Start();

    }
}
