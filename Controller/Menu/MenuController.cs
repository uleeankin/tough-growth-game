using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Menu
{
    public abstract class MenuController : Controller
    {

        protected Model.Menu.Menu Menu { get; set; }
        protected View.Menu.ViewMenu ViewMenu { get; set; }

        public MenuController()
            : base()
        {
            
        }
    }
}
