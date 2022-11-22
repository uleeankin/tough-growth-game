using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Menu
{
    public abstract class InfoController : Controller
    {
        protected Model.Menu.MenuScreen Info { get; set; }

        public InfoController() : base()
        {

        }
    }
}
