using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Menu
{
    public abstract class ViewMenu : View
    {
        private Model.Menu.Menu _menu = null;

        private Dictionary<int, ViewMenuItem> _items = null;

        protected ViewMenuItem[] Menu => _items.Values.ToArray();

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; protected set; }
        public int Height { get; protected set; }

        public ViewMenuItem this[int parId]
        {
            get
            {
                return _items[parId];
            }
        }

        public ViewMenu(Model.Menu.Menu parMenu)
        {
            _menu = parMenu;
            _items = new Dictionary<int, ViewMenuItem>();

            foreach (Model.Menu.MenuItem elMenuItem in parMenu.Items)
            {
                _items.Add(elMenuItem.ID, CreateItem(elMenuItem));
            }
            _menu.Redraw += Redraw;
        }

        protected abstract void Redraw();
        protected abstract ViewMenuItem CreateItem(Model.Menu.MenuItem parMenuItem);
    }
}
