using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Menu
{
    public abstract class MenuController : Controller
    {

        protected Model.Menu.MenuScreen Menu { get; set; }

        public MenuController()
            : base()
        {
            
        }
    }
}
