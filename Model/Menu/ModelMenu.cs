using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Menu
{
    public class ModelMenu : Model
    {
        private Menu _menu = null;

        public ModelMenu(Menu parMenu)
        {
            _menu = parMenu;
        }

        protected Menu Menu
        {
            get { return _menu; }
            set { _menu = value; }
        } 
    }
}
