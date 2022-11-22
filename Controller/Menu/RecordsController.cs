using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Menu
{
    public abstract class RecordsController : Controller
    {
        protected Model.Menu.MenuScreen Records { get; set; }

        public RecordsController() : base()
        {

        }
    }
}
