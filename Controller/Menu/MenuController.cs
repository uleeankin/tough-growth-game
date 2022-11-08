using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Menu
{
    public abstract class MenuController : Controller
    {

        public MenuController(Model.Menu.ModelMenu model,
                                    View.Menu.ViewMenu view)
            : base(model, view)
        {

        }
    }
}
