using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Items;

namespace View.Menu
{
    public abstract class ViewMenu : View
    {
        private Model.Menu.MenuScreen _menu = null;

        private Dictionary<int, ViewControlItem> _items = null;

        protected ViewControlItem[] Menu => _items.Values.ToArray();

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; protected set; }
        public int Height { get; protected set; }

        public ViewControlItem this[int parId]
        {
            get
            {
                return _items[parId];
            }
        }

        public ViewMenu(Model.Menu.MenuScreen parMenu)
        {
            _menu = parMenu;
            _items = new Dictionary<int, ViewControlItem>();

            foreach (Model.Items.ControlItem elMenuItem in parMenu.ControlItems)
            {
                _items.Add(elMenuItem.ID, CreateItem(elMenuItem));
            }
        }

        protected abstract void Redraw();
        protected abstract ViewControlItem CreateItem(Model.Items.ControlItem parMenuItem);
    }
}
